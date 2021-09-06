using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _06_03_XX_Serializacao_Binaria_Personalizada_Contrato.Depois
{
    public class LojaDeFilmes7
    {
        private List<Diretor7> diretores;

        public List<Diretor7> Diretores
        {
            get { return diretores; }
            set
            {
                diretores = value;
            }
        }

        private List<Filme7> filmes;

        public IReadOnlyCollection<Filme7> Filmes
        {
            get { return new ReadOnlyCollection<Filme7>(filmes); }
        }

        public LojaDeFilmes7()
        {
            Inicializar();
        }

        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }

        private void Inicializar()
        {
            Diretores = new List<Diretor7>
                {
                    new Diretor7("James Cameron", 5),
                    new Diretor7("Francis Lawrence", 3),
                    new Diretor7("Zack Snyder", 6),
                    new Diretor7("Joss Whedon", 7),
                    new Diretor7("Martin Scorsese", 4),
                    new Diretor7("Christopher Nolan", 8),
                    new Diretor7("Scott Derrickson", 4),
                    new Diretor7("Gareth Edwards", 3),
                    new Diretor7("Justin Kurzel", 6)
                };

            filmes = new List<Filme7> {
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
                };
        }
    }

    public class Diretor7
    {
        public string Nome { get; }
        public int NumeroFilmes { get; }

        public Diretor7(string nome, int numeroFilmes)
        {
            Nome = nome;
            NumeroFilmes = numeroFilmes;
        }
    }

    public class Filme7
    {
        public Filme7(Diretor7 diretor, string titulo, string ano)
        {
            Diretor = diretor;
            Titulo = titulo;
            Ano = ano;
        }

        public Diretor7 Diretor { get; }
        public string Titulo { get; }
        public string Ano { get; }

        public override string ToString()
        {
            return $"{Titulo} - {Ano}";
        }
    }
}