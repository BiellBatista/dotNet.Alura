using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var sql = @"SELECT a.*
                            FROM actor a
                            	INNER JOIN 
                            (SELECT TOP 5 a.actor_id, COUNT(*) AS total
                            FROM actor a
                            	INNER JOIN film_actor fa ON fa.actor_id = a.actor_id
                            GROUP BY a.actor_id
                            ORDER BY total DESC)
                            filmes ON filmes.actor_id = a.actor_id";
                //usando uma view
                /*
                 * Quando um SQL for muito usado, é bom passar ele para VIEW
                 */
                var sql2 = @"SELECT a.*
                             FROM actor a
                                INNER JOIN top5_most_starred_actors filmes
                                ON filmes.actor_id = a.actor_id";

                //falando para o EF usar o meu SQL e não gerar um novo
                var atoresMaisAtuantes = contexto.Atores.FromSql(sql)
                                            .Include(a => a.Filmografia);
                var atoresMaisAtuantes2 = contexto.Atores.FromSql(sql2)
                                            .Include(a => a.Filmografia);

                foreach (var ator in atoresMaisAtuantes2)
                {
                    Console.WriteLine($"O autor {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                }

                Console.ReadLine();
            }
        }
    }
}
