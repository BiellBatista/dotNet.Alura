﻿using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }
        public IList<PromocaoProduto> Promocoes { get; set; } // devo colocar uma lista para indicar N:M. No caso, a tabela intermediaria
        public IList<Compra> Compras { get; set; } //UM PRODUTO ESTÁ EM VÁRIAS COMPRAS
        public override string ToString()
        {
            return $"Produto: {Id}, {Nome}, {Categoria}, {PrecoUnitario} - ";
        }
    }
}