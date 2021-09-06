using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _06_01_XX_Serializacao_XML.Depois
{
    ///<image url="$(ProjectDir)/img01.png"/>
    ///<image url="$(ProjectDir)/img02.png"/>
    public class SerializacaoBinaria : IAulaItem
    {
        public void Executar()
        {
            var loja = ObterDados();

            var binaryFormatter = new BinaryFormatter();

            using (var fileStream = new FileStream("Loja.bin", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, loja);
            }

            LojaDeFilmes3 copiaDaLoja;

            using (var fileStream = new FileStream("Loja.bin", FileMode.Open, FileAccess.Read))
            {
                copiaDaLoja = (LojaDeFilmes3)binaryFormatter.Deserialize(fileStream);
            }

            foreach (var filme in copiaDaLoja.Filmes)
            {
                Console.WriteLine(filme.Titulo);
            }

            Console.ReadKey();
        }

        private static LojaDeFilmes3 ObterDados()
        {
            return new LojaDeFilmes3
            {
                Diretores = new List<Diretor3>
                {
                    new Diretor3 { Nome = "James Cameron", NumeroFilmes = 5 },
                    new Diretor3 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                    new Diretor3 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                    new Diretor3 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                    new Diretor3 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                    new Diretor3 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                    new Diretor3 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                    new Diretor3 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                    new Diretor3 { Nome = "Justin Kurzel", NumeroFilmes = 6 }
                },
                Filmes = new List<Filme3> {
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "James Cameron", NumeroFilmes = 5 },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                        Titulo = "Interstellar",
                        Ano = "2014"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Game of Thrones",
                        Ano = "2011–"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Vikings",
                        Ano = "2013–"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Gotham",
                        Ano = "2014–"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Power",
                        Ano = "2014–"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Narcos",
                        Ano = "2015–"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Breaking Bad",
                        Ano = "2008–2013"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "Justin Kurzel", NumeroFilmes = 6 },
                        Titulo = "Assassin's Creed",
                        Ano = "2016"
                    },
                    new Filme3 {
                        Diretor = new Diretor3 { Nome = "N/A" },
                        Titulo = "Luke Cage",
                        Ano = "2016–"
                    }
                }
            };
        }
    }
}