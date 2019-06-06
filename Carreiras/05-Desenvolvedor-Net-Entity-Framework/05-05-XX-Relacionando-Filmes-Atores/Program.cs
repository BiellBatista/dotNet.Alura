using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
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

                var categorias = contexto.Categorias
                    .Include(c => c.Filmes)
                    .ThenInclude(fc => fc.Filme);

                foreach (var c in categorias)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Filmes da categoria {c}:");
                    foreach (var fc in c.Filmes)
                    {
                        Console.WriteLine(fc.Filme);
                    }
                }

                //var filme = contexto.Filmes
                //    .Include(f => f.Atores) //pedido para realizar um join com Atores que está na tabea filme
                //    .ThenInclude(fa => fa.Ator) //adicinando mais um join, pegando o ator que está na tabela FilmeAtor
                //    .First();

                //Console.WriteLine(filme);
                //Console.WriteLine("Elenco");


                //foreach (var ator in filme.Atores)
                //{
                //    Console.WriteLine(ator.Ator);
                //}

                //foreach (var item in contexto.Elenco)
                //{
                //    //pegando a entidade para que eu possa pegar as propriedades ocultas
                //    var entidade = contexto.Entry(item);
                //    //pegando as propriedades shadow
                //    var filmId = entidade.Property("film_id").CurrentValue;
                //    var actorId = entidade.Property("actor_id").CurrentValue;
                //    var lastUpdate = entidade.Property("last_update").CurrentValue;

                //    Console.WriteLine($"Filme: {filmId}, Ator: {actorId}, LastUpdate: {lastUpdate}");
                //}

                Console.ReadLine();
            }
        }
    }
}