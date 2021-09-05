using _08_04_XX_Gerenciando_Diretorios.Depois;
using System;
using System.Collections.Generic;

namespace _08_04_XX_Gerenciando_Diretorios
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
                new MenuItem("Ler e Gravar Strings em Fluxos de Arquivos", typeof(LerGravarStringsFluxosArquivos01)),
                new MenuItem("Gravando e Lendo Texto de Arquivos com StreamWriter e StreamReader", typeof(LerGravarStringsFluxosArquivos02)),
                new MenuItem("Gravando e Lendo Arquivo Compactado", typeof(LerGravarStringsFluxosArquivos03)),
                new MenuItem("Gerenciando Arquivos", typeof(GerenciandoArquivos01)),
                new MenuItem("Tratando Exceções de Fluxo", typeof(GerenciandoArquivos02)),
                new MenuItem("Obtendo Informações Sobre os Drives", typeof(GerenciandoArquivos03)),
                new MenuItem("Informações do Arquivo", typeof(GerenciandoArquivos04)),
                new MenuItem("Gerenciando Diretórios", typeof(GerenciandoDiretorios01)),
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