using _06_06_XX_Conjuntos_Dicionarios_Filas.Depois;
using System;
using System.Collections.Generic;

namespace _06_06_XX_Conjuntos_Dicionarios_Filas
{
    internal class Program
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
                new MenuItem("Serialização com XML", typeof(SerializacaoComXML)),
                new MenuItem("Serialização com JSON", typeof(SerializacaoComJSON)),
                new MenuItem("Serialização Binária", typeof(SerializacaoBinaria)),
                new MenuItem("Serialização Personalizada", typeof(SerializacaoPersonalizada)),
                new MenuItem("Serialização Contrato", typeof(SerializacaoComContrato)),
                new MenuItem("Arrays", typeof(Arrays)),
                new MenuItem("Listas", typeof(Listas)),
                new MenuItem("Conjuntos", typeof(Conjuntos)),
                new MenuItem("Dicionários", typeof(Dicionarios)),
                new MenuItem("Dicionários", typeof(Filas)),
                new MenuItem("Escolher os Tipos", typeof(EscolherTipos)),
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