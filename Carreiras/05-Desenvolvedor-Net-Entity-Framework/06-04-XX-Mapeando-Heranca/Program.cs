using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                Console.WriteLine("Clientes:");
                foreach (var cliente in contexto.Clientes)
                {
                    Console.WriteLine(cliente);
                }

                Console.WriteLine("Funcionários:");
                foreach (var funcionario in contexto.Funcionarios)
                {
                    Console.WriteLine(funcionario);
                }

                Console.ReadLine();
            }
        }
    }
}

/*
 * Herança - Padrões de Mapeamento
 * 
 * TPH - Table Per Hierarchy: ele cria uma única tabela para a hierarquia.
 * TPC - Table Per Concrete Type: ele cria uma tabela por classes concretas. Ele vai lá na classe filha e vai criar uma tabela por cada classe (esse seria o padrão utilizado na aula 04, se eu tivesse colocado a tabela Pessoa no contexto para ser rastreada)
 * TPT - Table Per Type: ele cria uma tabela para todos os tipos que estão na hierarquia.
 */