﻿using _02_05_XX_CasaDoCodigo.Models;

namespace _02_05_XX_CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {

    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
