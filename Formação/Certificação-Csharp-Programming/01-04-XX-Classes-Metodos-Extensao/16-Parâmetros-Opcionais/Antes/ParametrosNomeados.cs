﻿using System;

namespace _01_04_XX_Classes_Metodos_Extensao.Antes
{
    internal class ParametrosNomeados : IAulaItem
    {
        public void Executar()
        {
        }

        private void ImprimirDetalhesDoPedido(string vendedor, int numeroPedido, string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(vendedor))
            {
                throw new ArgumentException(message: "Nome de vendedor não pode ser nulo ou vazio.", paramName: nameof(vendedor));
            }

            Console.WriteLine($"Vendedor: {vendedor}, Pedido No.: {numeroPedido}, Produto: {nomeProduto}");
        }
    }
}