﻿using _03_03_XX_CasaDoCodigo.Models;
using _03_03_XX_CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _03_03_XX_CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigoProduto);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem(string codigoProduto)
        {
            var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigoProduto)
                .SingleOrDefault();

            if (produto is null)
                throw new ArgumentException("Produto não encontrado");

            var pedido = GetPedido();
            var itemPedido = contexto.Set<ItemPedido>()
                .Where(i => i.Produto.Codigo == codigoProduto
                    && i.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if (itemPedido is null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);
                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                contexto.SaveChanges();
                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            //pegado o id do pedido da session
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            //salvando o id do pedido na ssessão
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedido is null)
                throw new ArgumentException("ItemPedido não encontrado");

            itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

            if (itemPedido.Quantidade == 0)
                itemPedidoRepository.RemoveItemPedido(itemPedido.Id);

            contexto.SaveChanges();

            var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);

            return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
        }
    }
}
