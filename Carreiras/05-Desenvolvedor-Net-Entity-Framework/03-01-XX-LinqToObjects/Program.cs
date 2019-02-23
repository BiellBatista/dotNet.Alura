using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01_XX_LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void ListandoGenerosRock()
        {
            // listar todos os generos que tem a palavra rock
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock"},
                new Genero { Id = 2, Nome =  "Reggae"},
                new Genero { Id = 3, Nome =  "Rock Progressivo"},
                new Genero { Id = 4, Nome =  "Punk"},
                new Genero { Id = 5, Nome =  "Clássica"}
            };
            Console.WriteLine("Lista com resultado de uma busca sem query e com if");
            foreach (var genero in generos)
                if (genero.Nome.Contains("Rock"))
                    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            Console.WriteLine("Lista com resultado de uma query");
            // select * from generos
            // o"g" é a variável interna que representa UM objeto da conjunta
            //var query = from g in generos select g;
            var query = from g in generos where g.Nome.Contains("Rock") select g;
            foreach (var genero in query)
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
        }
    }

    class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
