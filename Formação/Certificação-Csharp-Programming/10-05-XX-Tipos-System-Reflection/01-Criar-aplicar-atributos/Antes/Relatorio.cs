using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _10_05_XX_Tipos_System_Reflection.Antes
{
    internal interface IRelatorio
    {
        string Nome { get; set; }

        void Imprimir();
    }

    internal class Relatorio : IRelatorio
    {
        public string Nome { get; set; }
        private readonly IList<Venda> vendas;

        public Relatorio(string nome)
        {
            Nome = nome;
            vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
        }

        public void Imprimir()
        {
            Cabecalho();
            ListagemResumida();
            ListagemDetalhada();

            Console.WriteLine();
        }

        private void Cabecalho()
        {
            Console.WriteLine(Nome);
            Console.WriteLine("=============================");
        }

        private void ListagemDetalhada()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
            Console.WriteLine("==========================================================================================================================================");

            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }

            Console.WriteLine();
        }

        private void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");

            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}"
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }

            Console.WriteLine();
        }
    }
}