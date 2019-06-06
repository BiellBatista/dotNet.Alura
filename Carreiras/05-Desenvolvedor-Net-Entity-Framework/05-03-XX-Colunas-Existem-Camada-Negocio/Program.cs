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
                foreach (var ator in contexto.Atores)
                {
                    System.Console.WriteLine(ator);
                    //contexto.Entry(ator).Property("las_update").CurrentValue = DateTime.Now; //adicionado um valor para uma propriedade shadow. Tenho que fazer isso porque ela não pode, pela regra de negócio, ser declada na entidade Ator e, consequentemente, não consigo acessar a propriedade pelo objeto ator
                }
                System.Console.ReadLine();
            }
        }
    }
}