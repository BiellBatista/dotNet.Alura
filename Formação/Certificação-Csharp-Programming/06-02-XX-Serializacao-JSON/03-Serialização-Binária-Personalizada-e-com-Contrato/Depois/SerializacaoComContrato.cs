using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace _06_02_XX_Serializacao_JSON.Depois
{
    public class SerializacaoComContrato : IAulaItem
    {
        public void Executar()
        {
            LojaDeFilmes5 loja = ObterDados();

            var serializer = new DataContractSerializer(typeof(LojaDeFilmes5));

            using (var fileStream = new FileStream("Loja.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.WriteObject(fileStream, loja);
            }
        }

        private static LojaDeFilmes5 ObterDados()
        {
            return new LojaDeFilmes5
            {
                Diretores = new List<Diretor5>
                {
                    new Diretor5 { Nome = "James Cameron", NumeroFilmes = 5 },
                    new Diretor5 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                    new Diretor5 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                    new Diretor5 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                    new Diretor5 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                    new Diretor5 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                    new Diretor5 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                    new Diretor5 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                    new Diretor5 { Nome = "Justin Kurzel", NumeroFilmes = 6 }
                },
                Filmes = new List<Filme5> {
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "James Cameron", NumeroFilmes = 5 },
                        Titulo = "Avatar",
                        Ano = "2009"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Francis Lawrence", NumeroFilmes = 3 },
                        Titulo = "I Am Legend",
                        Ano = "2007"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Zack Snyder", NumeroFilmes = 6 },
                        Titulo = "300",
                        Ano = "2006"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Joss Whedon", NumeroFilmes = 7 },
                        Titulo = "The Avengers",
                        Ano = "2012"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Martin Scorsese", NumeroFilmes = 4 },
                        Titulo = "The Wolf of Wall Street",
                        Ano = "2013"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Christopher Nolan", NumeroFilmes = 8 },
                        Titulo = "Interstellar",
                        Ano = "2014"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Game of Thrones",
                        Ano = "2011–"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Vikings",
                        Ano = "2013–"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Gotham",
                        Ano = "2014–"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Power",
                        Ano = "2014–"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Narcos",
                        Ano = "2015–"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Breaking Bad",
                        Ano = "2008–2013"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Scott Derrickson", NumeroFilmes = 4 },
                        Titulo = "Doctor Strange",
                        Ano = "2016"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Gareth Edwards", NumeroFilmes = 3 },
                        Titulo = "Rogue One: A Star Wars Story",
                        Ano = "2016"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "Justin Kurzel", NumeroFilmes = 6 },
                        Titulo = "Assassin's Creed",
                        Ano = "2016"
                    },
                    new Filme5 {
                        Diretor = new Diretor5 { Nome = "N/A" },
                        Titulo = "Luke Cage",
                        Ano = "2016–"
                    }
                }
            };
        }
    }
}