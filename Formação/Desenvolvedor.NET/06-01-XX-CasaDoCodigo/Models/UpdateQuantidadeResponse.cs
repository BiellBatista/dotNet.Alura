﻿using _06_01_XX_CasaDoCodigo.Models.ViewModels;

namespace _06_01_XX_CasaDoCodigo.Models
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carrinhoViewModel;
        }

        public ItemPedido ItemPedido { get; }
        public CarrinhoViewModel CarrinhoViewModel { get; }
    }
}
