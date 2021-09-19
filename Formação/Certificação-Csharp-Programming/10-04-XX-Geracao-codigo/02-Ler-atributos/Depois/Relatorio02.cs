using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _10_04_XX_Geracao_codigo.Depois
{
    internal interface IRelatorio02
    {
        string Nome { get; set; }

        void Imprimir();
    }

    internal class Relatorio02 : IRelatorio02
    {
        public string Nome { get; set; }
        private readonly IList<Venda02> vendas;

        public Relatorio02(string nome)
        {
            Nome = nome;
            vendas = JsonConvert.DeserializeObject<List<Venda02>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            Cabecalho();
            ListagemResumida();
            ListagemDetalhada();
            Console.WriteLine();
        }

        [Conditional("RELATORIO_DETALHADO"), Conditional("RELATORIO_RESUMIDO")]
        private void Cabecalho()
        {
            Console.WriteLine(Nome);
            Console.WriteLine("=============================");
        }

        [Conditional("RELATORIO_DETALHADO")]
        private void ListagemDetalhada()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
            Console.WriteLine("==========================================================================================================================================");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda02), typeof(FormatoDetalhado02Attribute));
            FormatoDetalhado02Attribute formatoDetalhado = (FormatoDetalhado02Attribute)a;

            foreach (var venda in vendas)
            {
                Console.WriteLine(formatoDetalhado.Formato, venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
        }

        [Conditional("RELATORIO_RESUMIDO")]
        private void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda02), typeof(FormatoResumido02Attribute));
            FormatoResumido02Attribute formatoResumido = (FormatoResumido02Attribute)a;

            foreach (var venda in vendas)
            {
                Console.WriteLine(formatoResumido.Formato, venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
        }
    }
}