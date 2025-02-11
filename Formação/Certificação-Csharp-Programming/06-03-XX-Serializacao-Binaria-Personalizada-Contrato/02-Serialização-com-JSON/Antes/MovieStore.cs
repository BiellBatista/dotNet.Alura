﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace _06_03_XX_Serializacao_Binaria_Personalizada_Contrato.Antes
{
    public class MovieStore2
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

    public class Director2
    {
        public string Name { get; set; }

        [XmlIgnore]
        public int NumberOfMovies;
    }

    public class Movie2
    {
        public Director Director { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}