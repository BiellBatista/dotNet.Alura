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
                //var ator1 = new Ator();
                //ator1.PrimeiroNome = "Tom";
                //ator1.UltimoNome = "Hanks";
                //contexto.Entry(ator1).Property("las_update").CurrentValue = DateTime.Now; //adicionado um valor para uma propriedade shadow. Tenho que fazer isso porque ela não pode, pela regra de negócio, ser declada na entidade Ator e, consequentemente, não consigo acessar a propriedade pelo objeto ator1

                //foreach (var ator in contexto.Atores)
                //{
                //    //Console.WriteLine(ator);
                //    //Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue); //mostrando o valor da propriedade shadow
                //}

                //listar os 10 atores  modificados recentemente
                var atores = contexto.Atores
                    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update")) //pegando o valor da propriedade shadow e usando como parametro para executar um order by desc
                    .Take(10); //pegando apenas os 10 primeiro

                foreach (var ator in atores)
                    Console.WriteLine($"{ator} - {contexto.Entry(ator).Property("last_update").CurrentValue}");
                Console.ReadLine();
            }
        }
    }
}