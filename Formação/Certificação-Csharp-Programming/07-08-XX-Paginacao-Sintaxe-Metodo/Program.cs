using System;
using System.Collections.Generic;
using _07_08_XX_Paginacao_Sintaxe_Metodo.Depois;

namespace _07_08_XX_Paginacao_Sintaxe_Metodo
{
    class Program
    {
        static IList<MenuItem> menuItems;

        static void Main(string[] args)
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
                new MenuItem("Introdução aos Eventos", typeof(IntroducaEventos)),
                new MenuItem("Manipuladores de Eventos", typeof(ManipuladoresEventos)),
                new MenuItem("Delegados e Lambda", typeof(DelegadosLambda)),
                new MenuItem("Func, Action e Predicate", typeof(FuncActionPredicate)),
                new MenuItem("Consultando e Filtrando Dados com LINQ", typeof(ConsultandoFiltrandoDadosLINQ)),
                new MenuItem("Projeção de Dados", typeof(ProjecaoDados)),
                new MenuItem("Agrupamento e Agregação", typeof(AgrupamentoAgregacao)),
                new MenuItem("Paginação e Sintaxe de Método", typeof(ExecucaoAdiadaImediata)),
                new MenuItem("Consulta com XML", typeof(ConsultaXML)),
            };
        }
    }

    class MenuItem
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
