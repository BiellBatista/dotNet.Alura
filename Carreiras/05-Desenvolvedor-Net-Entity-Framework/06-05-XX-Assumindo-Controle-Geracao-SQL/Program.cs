using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
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

                var sql = @"SELECT TOP 5 a.first_name, a.last_name, COUNT(*) AS total
                            FROM actor a
	                            INNER JOIN film_actor fa ON fa.actor_id = a.actor_id
                            GROUP BY a.first_name, a.last_name
                            ORDER BY total DESC";

                //falando para o EF usar o meu SQL e não gerar um novo
                var atoresMaisAtuantes = contexto.Atores.FromSql(sql);

                foreach (var ator in atoresMaisAtuantes)
                {
                    Console.WriteLine($"O autor {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                }

                Console.ReadLine();
            }
        }
    }
}
