﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo_Refatoracao.R04.InlineTemp.depois
{
    class CalculadoraDePrecos
    {
        bool TemDesconto(Pedido pedido)
        {
            return (pedido.ValorProdutos() > 1000);
        }
    }

    class Pedido
    {
        private readonly DateTime clienteDesde;
        private readonly decimal valorProdutos;

        public Pedido(DateTime clienteDesde, decimal valorProdutos)
        {
            this.clienteDesde = clienteDesde;
            this.valorProdutos = valorProdutos;
        }

        public decimal ValorProdutos()
        {
            return valorProdutos;
        }

        public bool TemDesconto()
        {
            //aqui NÃO É um bom exemlo para inline method!
            bool clienteHaMaisDe5Anos = (DateTime.Today.Subtract(clienteDesde).TotalDays / 365) >= 5;
            bool compraEspecial = valorProdutos > 1000;
            return clienteHaMaisDe5Anos && compraEspecial;
        }
    }
}
