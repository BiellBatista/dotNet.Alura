﻿using System.Collections.Generic;

namespace _06_03_XX_Serializacao_Binaria_Personalizada_Contrato.Depois
{
    public class MovieStore
    {
        public List<Director> Directors = new List<Director>();
        public List<Movie> Movies = new List<Movie>();

        public static MovieStore AddMovie(Movie movie)
        {
            MovieStore store = new MovieStore();
            // ...
            return store;
        }
    }

    public class Director
    {
        public string Name { get; set; }
        public int NumberOfMovies;
    }

    public class Movie
    {
        public Director Director { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}