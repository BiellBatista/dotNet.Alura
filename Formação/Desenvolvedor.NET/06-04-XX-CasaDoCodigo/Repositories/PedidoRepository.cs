﻿using _06_04_XX_CasaDoCodigo.Areas.Identity.Data;
using _06_04_XX_CasaDoCodigo.Models;
using _06_04_XX_CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _06_04_XX_CasaDoCodigo.Repositories
{
    //MELHORIA: 6) Repositórios simplificados

    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoAsync();
        Task AddItemAsync(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido);
        Task<Pedido> UpdateCadastroAsync(Cadastro cadastro);
    }

    //TAREFA 06: INJETAR UserManager PARA OBTER clienteId
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IHttpHelper httpHelper;
        private readonly ICadastroRepository cadastroRepository;
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly IRelatorioHelper relatorioHelper;

        public PedidoRepository(IConfiguration configuration,
            ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IHttpHelper sessionHelper,
            ICadastroRepository cadastroRepository,
            UserManager<AppIdentityUser> userManager,
            IRelatorioHelper relatorioHelper) : base(configuration, contexto)
        {
            this.contextAccessor = contextAccessor;
            this.httpHelper = sessionHelper;
            this.cadastroRepository = cadastroRepository;
            this.userManager = userManager;
            this.relatorioHelper = relatorioHelper;
        }

        public async Task AddItemAsync(string codigo)
        {
            var produto = await
                            contexto.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync();

            var itemPedido = await
                                contexto.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                await
                    contexto.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedidoAsync()
        {
            var pedidoId = httpHelper.GetPedidoId();
            var pedido =
                await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                        .ThenInclude(prod => prod.Categoria)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                var claimsPrincipal = contextAccessor.HttpContext.User;
                //var clienteId = userManager.GetUserId(claimsPrincipal);
                // mudando o objeto que irá buscar o id do usuário no Identity Server
                // ? serve para caso o Value for nulo
                var clienteId = claimsPrincipal.FindFirst("sub")?.Value; //id do usuário no OpenId
                pedido = new Pedido(clienteId);
                await dbSet.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                httpHelper.SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido)
        {
            var itemPedidoDB = await GetItemPedidoAsync(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await RemoveItemPedidoAsync(itemPedido.Id);
                }

                await contexto.SaveChangesAsync();

                var pedido = await GetPedidoAsync();
                var carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateCadastroAsync(Cadastro cadastro)
        {
            var pedido = await GetPedidoAsync();
            await cadastroRepository.UpdateAsync(pedido.Cadastro.Id, cadastro);
            httpHelper.ResetPedidoId();
            await relatorioHelper.GerarRelatorio(pedido);
            return pedido;
        }

        private async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await contexto.Set<ItemPedido>()
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            contexto.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
}
