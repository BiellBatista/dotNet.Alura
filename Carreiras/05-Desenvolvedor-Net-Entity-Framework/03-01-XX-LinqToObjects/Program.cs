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
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock"},
                new Genero { Id = 2, Nome =  "Reggae"},
                new Genero { Id = 3, Nome =  "Rock Progressivo"},
                new Genero { Id = 4, Nome =  "Punk"},
                new Genero { Id = 5, Nome =  "Clássica"}
            };

            // listando todas as musica do genero Rock
            var musicas = new List<Musica>
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
                new Musica { Id = 2, Nome = "I Shoot The Sheriff", GeneroId = 2},
                new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 5},
            };

            //em uma clausula SELECT. não consigo trazer uma lista de valores, mas SEMPRE UM objeto
            var query = from m in musicas
                        join g in generos
                            on m.GeneroId equals g.Id
                        select new { m, g };

            // listando musicas
            //foreach (var musica in musicas)
            //    Console.WriteLine("{0}\t{1}\t{2}", musica.Id, musica.Nome, musica.GeneroId);
            // listando as músicas e seu genero
            foreach (var musica in query)
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);

            // Crie uma consulta para listar os nomes das músicas cujo gênero tenha o nome "Reggae".
            /*
             * var query = 
from m in musicas
join g in generos on m.GeneroId equals g.Id
where g.Nome == "Reggae"
select m.Nome;
             */
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
            //Uma expressão Linq precisa começar pela cláusula from, e não pela cláusula select:
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

    class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
