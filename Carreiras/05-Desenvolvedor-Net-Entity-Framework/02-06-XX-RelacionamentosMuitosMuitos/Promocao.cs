using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime Inicio { get; internal set; }
        public DateTime Termino { get; internal set; }
        public IList<PromocaoProduto> Produtos { get; internal set; } // devo colocar uma lista para indicar N:M. No caso, a tabela intermediaria

        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        public void IncluirProduto(Produto p)
        {
            Produtos.Add(new PromocaoProduto() { Produto = p });
        }
    }
}
