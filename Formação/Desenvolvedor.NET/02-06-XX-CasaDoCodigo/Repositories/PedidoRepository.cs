﻿using _02_06_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _02_06_XX_CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigoProduto);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
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
    }
}
