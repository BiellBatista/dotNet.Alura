﻿namespace _02_01_XX_CasaDoCodigo
{
    public class Livro
    {
        public Livro(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
