using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace _06_01_XX_Serializacao_XML.Depois
{
    public class SerializacaoPersonalizada : IAulaItem
    {
        public void Executar()
        {
            LojaDeFilmes4 loja = ObterDados();

            var serializer = new DataContractSerializer(typeof(LojaDeFilmes4));

            using (var fileStream = new FileStream("Loja.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(fileStream, loja);
            }

            LojaDeFilmes4 copiaDaLoja;

            using (var fileStream = new FileStream("Loja.xml", FileMode.Open, FileAccess.Read))
            {
                copiaDaLoja = (LojaDeFilmes4)serializer.ReadObject(fileStream);
            }

            foreach (var filme in copiaDaLoja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

            Console.ReadKey();
        }

        private static LojaDeFilmes4 ObterDados()
        {
            return new LojaDeFilmes4
            {
                Diretores = new List<Diretor4>
                {
                    new Diretor4 { Nome = "James Cameron", NumeroFilmes = 5 },
                    new Diretor4 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                    new Diretor4 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                    new Diretor4 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                    new Diretor4 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                    new Diretor4 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                    new Diretor4 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                    new Diretor4 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                    new Diretor4 { Nome = "Justin Kurzel", NumeroFilmes = 6 }
                },
                Filmes = new List<Filme4> {
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "James Cameron", NumeroFilmes = 5 },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                        Titulo = "Interstellar",
                        Ano = "2014"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Game of Thrones",
                        Ano = "2011–"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Vikings",
                        Ano = "2013–"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Gotham",
                        Ano = "2014–"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Power",
                        Ano = "2014–"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Narcos",
                        Ano = "2015–"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Breaking Bad",
                        Ano = "2008–2013"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "Justin Kurzel", NumeroFilmes = 6 },
                        Titulo = "Assassin's Creed",
                        Ano = "2016"
                    },
                    new Filme4 {
                        Diretor = new Diretor4 { Nome = "N/A" },
                        Titulo = "Luke Cage",
                        Ano = "2016–"
                    }
                }
            };
        }
    }
}