﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace _06_02_XX_Serializacao_JSON.Antes
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

        [XmlIgnore]
        public int NumberOfMovies;
    }

    public class Movie
    {
        public Director Director { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}