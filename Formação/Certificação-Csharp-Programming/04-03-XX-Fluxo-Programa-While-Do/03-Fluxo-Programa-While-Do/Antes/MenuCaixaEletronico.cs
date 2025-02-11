﻿using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace _04_03_XX_Fluxo_Programa_While_Do.Antes
{
    internal class MenuCaixaEletronico
    {
        private delegate void ItemMenu();

        public void Executar()
        {
            var itensMenu = new ItemMenu[]
            {
                Saque,
                ExtratoOuSaldo,
                Depositos,
                Transferencias,
                Emprestimo,
                Outros
            };

            int opcao = -1;

            while (opcao != 0)
            {
                opcao = GerarMenu(itensMenu);
            }
        }

        private static int GerarMenu(ItemMenu[] itensMenu)
        {
            ImprimirMenu(itensMenu);

            return GetOpcao(itensMenu);
        }

        private static int GetOpcao(ItemMenu[] itensMenu)
        {
            Console.Write("Digite uma opção: ");

            string input = Console.ReadLine();
            int.TryParse(input, out int opcao);

            if (opcao > 0)
            {
                itensMenu[opcao - 1]();
            }

            Console.WriteLine();
            Console.WriteLine("Digite algo para continuar...");
            Console.ReadKey();

            return opcao;
        }

        private static void ImprimirMenu(ItemMenu[] itensMenu)
        {
            Console.WriteLine(
@"
█▀▀▄ █░░█ ▀▀█▀▀ █▀▀ █▀▀▄ █▀▀█ █▀▀▄ █░█
█▀▀▄ █▄▄█ ░░█░░ █▀▀ █▀▀▄ █▄▄█ █░░█ █▀▄
▀▀▀░ ▄▄▄█ ░░▀░░ ▀▀▀ ▀▀▀░ ▀░░▀ ▀░░▀ ▀░▀");

            for (int i = 0; i < itensMenu.Length; i++)
            {
                string name = itensMenu[i].Method.Name;
                var descricao = Regex.Replace(name, "([A-Z]{1,2}|[0-9]+)", " $1").TrimStart();

                Console.WriteLine($"{i + 1} - {descricao}");
            }

            Console.WriteLine($"0 - Sair");
            Console.WriteLine();
        }

        private void Outros()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Emprestimo()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Transferencias()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Depositos()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void Saque()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        private void ExtratoOuSaldo()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
    }
}