﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _10_05_XX_Tipos_System_Reflection.Antes
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
            //#if RELATORIO_RESUMIDO
            ListagemResumida();
            //#endif
            //#if RELATORIO_DETALHADO
            ListagemDetalhada();
            //#endif
            Console.WriteLine();
        }

        [Conditional("RELATORIO_RESUMIDO"),
            Conditional("RELATORIO_DETALHADO")]
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

            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }

            Console.WriteLine();
        }

        [Conditional("RELATORIO_RESUMIDO")]
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