﻿using _08_01_XX_Ler_Gravar_Bytes_Fluxos_Arquivos.Depois;
using System;
using System.Collections.Generic;

namespace _08_01_XX_Ler_Gravar_Bytes_Fluxos_Arquivos
{
    public class Program
    {
        private static IList<MenuItem> menuItems;

        private static void Main(string[] args)
        {
            IAulaItem itemSelecionado;

            menuItems = GetMenuItems();

            while (true)
            {
                ImprimirMenuItems(menuItems);
                var opcao = Console.ReadLine();

                int.TryParse(opcao, out int valorOpcao);

                if (valorOpcao == 0)
                {
                    break;
                }

                if (valorOpcao > menuItems.Count)
                {
                    break;
                }

                itemSelecionado = Executar(valorOpcao);

                Console.ReadKey();
            }
        }

        private static IAulaItem Executar(int valorOpcao)
        {
            IAulaItem itemSelecionado;
            MenuItem menuItem = menuItems[valorOpcao - 1];
            Type tipoClasse = menuItem.TipoClasse;
            itemSelecionado = (IAulaItem)Activator.CreateInstance(tipoClasse);

            Console.WriteLine();

            string titulo = $"EXECUTANDO: {menuItem.Titulo}";
            Console.WriteLine(titulo);
            Console.WriteLine(new string('=', titulo.Length));

            itemSelecionado.Executar();
            Console.WriteLine();
            Console.WriteLine("Tecle algo para continuar...");

            return itemSelecionado;
        }

        private static void ImprimirMenuItems(IList<MenuItem> menuItems)
        {
            int i = 1;

            Console.WriteLine("SELECIONE UMA OPÇÃO");
            Console.WriteLine("===================");
            Console.WriteLine("0 - Sair");

            foreach (var menuItem in menuItems)
            {
                Console.WriteLine((i++).ToString() + " - " + menuItem.Titulo);
            }
        }

        private static IList<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>
            {
                new MenuItem("Ler e Gravar Bytes em Fluxos de Arquivos", typeof(LerGravarBytesFluxosArquivos01)),
            };
        }
    }

    internal class MenuItem
    {
        public MenuItem(string titulo, Type tipoClasse)
        {
            Titulo = titulo;
            TipoClasse = tipoClasse;
        }

        public string Titulo { get; set; }
        public Type TipoClasse { get; set; }
    }
}