using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();
                //poso executar comandos de INSERT, DELE e UPDATE no método ExecuteSqlCommand
                var insert = "INSERT INTO language(name) VALUES('Teste 1'), ('Teste 2'), ('Teste 3')";
                var delete = "DELETE FROM language WHERE name LIKE 'Teste%'";

                //executando os SQL
                var registrosInsert = contexto.Database.ExecuteSqlCommand(insert);
                var registrosDelete = contexto.Database.ExecuteSqlCommand(delete);

                Console.WriteLine($"O total de registros afetados é {registrosInsert}, {registrosDelete}");

                Console.ReadLine();
            }
        }

        static void StoredProcedure(DbContext contexto)
        {
            var categoria = "Action"; //36

            var paramCategoria = new SqlParameter("category_name", categoria); //Criando um parametro para minhas procedures
                                                                               //o primeiro argumento é nome do parametro que está definido na procedure/function e o segundo argumento é o valor
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };

            contexto.Database
                //a assinatura da procedure deve ser exatamente a mesma que está no banco de dados
                .ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT",
                                    paramCategoria,
                                    paramTotal); //executando um comando SQL (Procedure/Function)
                                                 //o último argumento é o valor de saída do ExecuteSqlCommand
            Console.WriteLine($"O total de atores na categoria {categoria} é de {paramTotal.Value}.");
        }
    }
}
