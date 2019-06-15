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

                var filme = new Filme();
                filme.Titulo = "Vingadores";
                filme.Duracao = 120;
                filme.AnoLancamento = "2012";
                filme.Classificacao = ClassificacaoIndicativa.MaioresQue13;
                filme.IdiomaFalado = contexto.Idiomas.First();

                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                var filmeInserido = contexto.Filmes.First(f => f.Titulo == "Vingadores");
                Console.WriteLine(filmeInserido.Classificacao);

                Console.ReadLine();
            }
        }
    }
}
