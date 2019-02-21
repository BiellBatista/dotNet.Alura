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
        public IList<Produto> Produtos { get; internal set; } // devo colocar uma lista para indicar N:M. Neste caso é Promocao : Produto
    }
}
