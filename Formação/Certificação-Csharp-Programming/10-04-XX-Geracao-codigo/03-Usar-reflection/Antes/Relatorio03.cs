using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _10_04_XX_Geracao_codigo.Antes
{
    internal interface IRelatorio03
    {
        string Nome { get; set; }

        void Imprimir();
    }

    internal class Relatorio03 : IRelatorio03
    {
        public string Nome { get; set; }
        private readonly IList<Venda03> vendas;

        public Relatorio03(string nome)
        {
            Nome = nome;
            vendas = JsonConvert.DeserializeObject<List<Venda03>>(File.ReadAllText("Vendas.json"));
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

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda03), typeof(FormatoDetalhado03Attribute));
            FormatoDetalhado03Attribute formatoDetalhado = (FormatoDetalhado03Attribute)a;

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

            Attribute a = Attribute.GetCustomAttribute(typeof(Venda03), typeof(FormatoResumido03Attribute));
            FormatoResumido03Attribute formatoResumido = (FormatoResumido03Attribute)a;

            foreach (var venda in vendas)
            {
                Console.WriteLine(formatoResumido.Formato, venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
        }
    }
}