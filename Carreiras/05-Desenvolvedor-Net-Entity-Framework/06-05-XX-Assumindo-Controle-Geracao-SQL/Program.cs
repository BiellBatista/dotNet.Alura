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
 * TPH - Table Per Hierarchy: Cria uma única tabela para armazenar os registros de toda a hierarquia de tipos. Para isso, precisará adicionar uma coluna para definir o tipo daquele registro.
 * TPC - Table Per Concrete Type: Nesse padrão, o Entity cria uma tabela para cada tipo concreto na hierarquia de tipos.
 * TPT - Table Per Type: O Entity cria uma tabela para cada tipo participante da hierarquia de tipos.
 */
