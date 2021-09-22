using _12_08_XX_Fazendo_Hash_Dados.Depois;
using System;
using System.Collections.Generic;

namespace _12_08_XX_Fazendo_Hash_Dados
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
                new MenuItem("Validar Dados JSON", typeof(Startup0101)),
                new MenuItem("Validar Dados JSON", typeof(Startup0102)),
                new MenuItem("Validar Dados JSON", typeof(Startup0103)),
                new MenuItem("Escolher o Tipo de Coleção Adequada", typeof(Startup0201)),
                new MenuItem("Validando com Expressão Regular", typeof(Startup0301)),
                new MenuItem("Validando com Expressão Regular", typeof(Startup0302)),
                new MenuItem("Funções Internas para Validar Tipos e Conteúdos", typeof(void)),
                new MenuItem("Funções Internas para Validar Tipos e Conteúdos", typeof(Startup0402)),
                new MenuItem("Criptografia Simétrica e Assimétrica", typeof(Startup0501)),
                new MenuItem("Criptografia Simétrica e Assimétrica", typeof(Startup0502)),
                new MenuItem("Criptografia Simétrica e Assimétrica", typeof(Startup0503)),
                new MenuItem("Gerenciamento de Chave", typeof(Startup0601)),
                new MenuItem("Gerenciamento de Chave", typeof(Startup0602)),
                new MenuItem("Gerenciamento de Chave", typeof(Startup0603)),
                new MenuItem("Gerenciar e Criar Certificados", typeof(Startup0701)),
                new MenuItem("Fazendo Hash de Dados", typeof(Startup0801)),
                new MenuItem("Fazendo Hash de Dados", typeof(Startup0802)),
                new MenuItem("Fazendo Hash de Dados", typeof(Startup0803)),
                new MenuItem("Fazendo Hash de Dados", typeof(Startup0804)),
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