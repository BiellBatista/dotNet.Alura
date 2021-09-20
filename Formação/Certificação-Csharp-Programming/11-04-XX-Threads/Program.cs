using _11_04_XX_Threads.Depois;
using System;
using System.Collections.Generic;

namespace _11_04_XX_Threads
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
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0101)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0102)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0103)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0104)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0105)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0106)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0107)),
                new MenuItem("Introdução ao Task Parallel Library", typeof(Startup0108)),
                new MenuItem("Consultas LINQ com Paralelismo", typeof(Startup0201)),
                new MenuItem("Espera, Continuação e Hierarquia de Tarefas", typeof(Startup0301)),
                new MenuItem("Threads", typeof(Startup0401)),
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