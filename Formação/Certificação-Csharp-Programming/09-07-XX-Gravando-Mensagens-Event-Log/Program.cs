using _09_07_XX_Gravando_Mensagens_Event_Log.Depois;
using System;
using System.Collections.Generic;

namespace _09_07_XX_Gravando_Mensagens_Event_Log
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
                new MenuItem("Gerenciando Assemblies", typeof(Startup)),
                new MenuItem("Assinando Assemblies com Nome Forte", typeof(Startup02)),
                new MenuItem("Depurando Aplicações", typeof(Startup03)),
                new MenuItem("Compilação Condicional", typeof(Startup04)),
                new MenuItem("Compilação em Modo Debug e Release", typeof(Startup05)),
                new MenuItem("Rastreamento de Aplicações", typeof(Startup06)),
                new MenuItem("Gravando Mensagens no Event Log", typeof(Startup07)),
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