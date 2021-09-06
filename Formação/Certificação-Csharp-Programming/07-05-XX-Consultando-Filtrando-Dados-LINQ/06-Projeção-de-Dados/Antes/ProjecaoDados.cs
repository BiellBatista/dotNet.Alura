using System;
using System.Collections.Generic;

namespace _07_05_XX_Consultando_Filtrando_Dados_LINQ.Antes
{
    public class ProjecaoDados : IAulaItem
    {
        public void Executar()
        {
            var filmes = GetFilmes();

            var novoFilme = new Filme2
            {
                Titulo = "A Fantástica Fábrica de Chocolate",
                Ano = 2005,
                Diretor = new Diretor2 { Id = 3, Nome = "Tim Burton" },
                DiretorId = 3
            };

            filmes.Add(novoFilme);

            Imprimir(filmes);

            Console.ReadKey();
        }

        private void Imprimir(List<Filme2> filmes)
        {
            Console.WriteLine($"{"Título",-40} {"Diretor",-20} {"Ano",4}");
            Console.WriteLine(new string('=', 64));
            foreach (var filme in filmes)
            {
                Console.WriteLine($"{filme.Titulo,-40} {filme.Diretor.Nome,-20} {filme.Ano,4}");
            }
        }

        private List<Diretor2> GetDiretores()
        {
            return new List<Diretor2>
            {
                new Diretor2 { Id = 1, Nome = "Quentin Tarantino" },
                new Diretor2 { Id = 2, Nome = "James Cameron" },
                new Diretor2 { Id = 3, Nome = "Tim Burton" }
            };
        }

        private static List<Filme2> GetFilmes()
        {
            return new List<Filme2> {
                new Filme2 {
                    DiretorId = 1,
                    Diretor = new Diretor2 { Nome = "Quentin Tarantino" },
                    Titulo = "Pulp Fiction",
                    Ano = 1994,
                    Minutos = 2 * 60 + 34
                },
                new Filme2 {
                    DiretorId = 1,
                    Diretor = new Diretor2 { Nome = "Quentin Tarantino" },
                    Titulo = "Django Livre",
                    Ano = 2012,
                    Minutos = 2 * 60 + 45
                },
                new Filme2 {
                    DiretorId = 1,
                    Diretor = new Diretor2 { Nome = "Quentin Tarantino" },
                    Titulo = "Kill Bill Volume 1",
                    Ano = 2003,
                    Minutos = 1 * 60 + 51
                },

                new Filme2 {
                    DiretorId = 2,
                    Diretor = new Diretor2 { Nome = "James Cameron" },
                    Titulo = "Avatar",
                    Ano = 2009,
                    Minutos = 2 * 60 + 42
                },
                new Filme2 {
                    DiretorId = 2,
                    Diretor = new Diretor2 { Nome = "James Cameron" },
                    Titulo = "Titanic",
                    Ano = 1997,
                    Minutos = 3 * 60 + 14
                },
                new Filme2 {
                    DiretorId = 2,
                    Diretor = new Diretor2 { Nome = "James Cameron" },
                    Titulo = "O Exterminador do Futuro",
                    Ano = 1984,
                    Minutos = 1 * 60 + 47
                },

                new Filme2 {
                    DiretorId = 3,
                    Diretor = new Diretor2 { Nome = "Tim Burton" },
                    Titulo = "O Estranho Mundo de Jack",
                    Ano = 1993,
                    Minutos = 1 * 60 + 16
                },
                new Filme2 {
                    DiretorId = 3,
                    Diretor = new Diretor2 { Nome = "Tim Burton" },
                    Titulo = "Alice no País das Maravilhas",
                    Ano = 2010,
                    Minutos = 1 * 60 + 48
                },
                new Filme2 {
                    DiretorId = 3,
                    Diretor = new Diretor2 { Nome = "Tim Burton" },
                    Titulo = "A Noiva Cadáver",
                    Ano = 2005,
                    Minutos = 1 * 60 + 17
                }
            };
        }
    }

    public class Diretor2
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Filme2
    {
        public int DiretorId { get; set; }
        public Diretor2 Diretor { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Minutos { get; set; }
    }
}