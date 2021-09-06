using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_08_XX_Paginacao_Sintaxe_Metodo.Depois
{
    public class ExecucaoAdiadaImediata : IAulaItem
    {
        public void Executar()
        {
            List<Diretor5> diretores = GetDiretores();
            List<Filme5> filmes = GetFilmes();

            var consulta = from f in filmes
                           where f.Diretor.Nome == "James Cameron"
                           select f;

            var consultaArray = consulta.ToArray();

            foreach (var item in consultaArray)
            {
                Console.WriteLine(item.Titulo);
            }

            Console.ReadKey();
        }

        private static void Imprimir(IEnumerable<Filme5> filmes)
        {
            Console.WriteLine($"{"Título",-40}{"Diretor",-20}{"Ano",4}");
            Console.WriteLine(new string('=', 64));

            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40}{filme.Diretor.Nome,-20}{filme.Ano}");
            }

            Console.WriteLine();
        }

        private static void Imprimir(IEnumerable<FilmeResumido4> filmes)
        {
            Console.WriteLine($"{"Título",-40}{"Diretor",-20}");
            Console.WriteLine(new string('=', 60));

            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40}{filme.NomeDiretor,-20}");
            }

            Console.WriteLine();
        }

        private static List<Diretor5> GetDiretores()
        {
            return new List<Diretor5>
            {
                new Diretor5 { Id = 1, Nome = "Quentin Tarantino" },
                new Diretor5 { Id = 2, Nome = "James Cameron" },
                new Diretor5 { Id = 3, Nome = "Tim Burton" }
            };
        }

        private static List<Filme5> GetFilmes()
        {
            return new List<Filme5> {
                new Filme5 {
                    DiretorId = 1,
                    Diretor = new Diretor5 { Nome = "Quentin Tarantino" },
                    Titulo = "Pulp Fiction",
                    Ano = 1994,
                    Minutos = 2 * 60 + 34
                },
                new Filme5 {
                    DiretorId = 1,
                    Diretor = new Diretor5 { Nome = "Quentin Tarantino" },
                    Titulo = "Django Livre",
                    Ano = 2012,
                    Minutos = 2 * 60 + 45
                },
                new Filme5 {
                    DiretorId = 1,
                    Diretor = new Diretor5 { Nome = "Quentin Tarantino" },
                    Titulo = "Kill Bill Volume 1",
                    Ano = 2003,
                    Minutos = 1 * 60 + 51
                },

                new Filme5 {
                    DiretorId = 2,
                    Diretor = new Diretor5 { Nome = "James Cameron" },
                    Titulo = "Avatar",
                    Ano = 2009,
                    Minutos = 2 * 60 + 42
                },
                new Filme5 {
                    DiretorId = 2,
                    Diretor = new Diretor5 { Nome = "James Cameron" },
                    Titulo = "Titanic",
                    Ano = 1997,
                    Minutos = 3 * 60 + 14
                },
                new Filme5 {
                    DiretorId = 2,
                    Diretor = new Diretor5 { Nome = "James Cameron" },
                    Titulo = "O Exterminador do Futuro",
                    Ano = 1984,
                    Minutos = 1 * 60 + 47
                },

                new Filme5 {
                    DiretorId = 3,
                    Diretor = new Diretor5 { Nome = "Tim Burton" },
                    Titulo = "O Estranho Mundo de Jack",
                    Ano = 1993,
                    Minutos = 1 * 60 + 16
                },
                new Filme5 {
                    DiretorId = 3,
                    Diretor = new Diretor5 { Nome = "Tim Burton" },
                    Titulo = "Alice no País das Maravilhas",
                    Ano = 2010,
                    Minutos = 1 * 60 + 48
                },
                new Filme5 {
                    DiretorId = 3,
                    Diretor = new Diretor5 { Nome = "Tim Burton" },
                    Titulo = "A Noiva Cadáver",
                    Ano = 2005,
                    Minutos = 1 * 60 + 17
                }
            };
        }
    }

    public class Diretor5
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Filme5
    {
        public int DiretorId { get; set; }
        public Diretor5 Diretor { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Minutos { get; set; }

        public override string ToString()
        {
            return $"{Diretor.Nome} - {Titulo}";
        }
    }

    public class FilmeResumido4
    {
        public string NomeDiretor { get; set; }
        public string Titulo { get; set; }
    }
}