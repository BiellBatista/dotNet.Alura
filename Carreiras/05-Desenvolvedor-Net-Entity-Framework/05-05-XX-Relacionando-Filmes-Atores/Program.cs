using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
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

                foreach (var item in contexto.Elenco)
                {
                    //pegando a entidade para que eu possa pegar as propriedades ocultas
                    var entidade = contexto.Entry(item);
                    //pegando as propriedades shadow
                    var filmId = entidade.Property("film_id").CurrentValue;
                    var actorId = entidade.Property("actor_id").CurrentValue;
                    var lastUpdate = entidade.Property("last_update").CurrentValue;

                    Console.WriteLine($"Filme: {filmId}, Ator: {actorId}, LastUpdate: {lastUpdate}");
                }

                Console.ReadLine();
            }
        }
    }
}