using System;
using System.Collections.Generic;

namespace _06_04_XX_Arrays.Antes
{
    public class Listas2 : IAulaItem
    {
        public void Executar()
        {
            throw new NotImplementedException();
        }
        private LojaDeFilmes7 GetLoja()
        {
            return new LojaDeFilmes7
            {
                Diretores = new List<Diretor7>
                {
                    new Diretor7("James Cameron",  5),
                    new Diretor7("Francis Lawrence",  3),
                    new Diretor7("Zack Snyder",  6),
                    new Diretor7("Joss Whedon",  7),
                    new Diretor7("Martin Scorsese",  4),
                    new Diretor7("Christopher Nolan",  8),
                    new Diretor7("Scott Derrickson",  4),
                    new Diretor7("Gareth Edwards",  3),
                    new Diretor7("Justin Kurzel",  6)
                },
                Filmes = new List<Filme7> {
                    new Filme7 (
                        new Diretor7 ( "James Cameron", 5 ),
                        "Avatar",
                        "2009"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Francis Lawrence", 3 ),
                        "I Am Legend",
                        "2007"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Zack Snyder", 6 ),
                        "300",
                        "2006"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Joss Whedon", 7 ),
                        "The Avengers",
                        "2012"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Martin Scorsese", 4 ),
                        "The Wolf of Wall Street",
                        "2013"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Christopher Nolan", 8 ),
                        "Interstellar",
                        "2014"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Jeremy Podeswa", 3 ),
                        "Game of Thrones",
                        "2011–"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Michael Hirst", 4 ),
                        "Vikings",
                        "2013–"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Danny Cannon", 1 ),
                        "Gotham",
                        "2014–"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Courtney Kemp", 1 ),
                        "Power",
                        "2014–"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Jose Padilha", 4 ),
                        "Narcos",
                        "2015–"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Vince Gilligan", 2 ),
                        "Breaking Bad",
                        "2008–2013"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Scott Derrickson", 4 ),
                        "Doctor Strange",
                        "2016"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Gareth Edwards", 3 ),
                        "Rogue One: A Star Wars Story",
                        "2016"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Justin Kurzel", 6 ),
                        "Assassin's Creed",
                        "2016"
                    ),
                    new Filme7 (
                        new Diretor7 ( "Charles Murray", 1 ),
                        "Luke Cage",
                        "2016–"
                    )
                }
            };
        }
    }
}
