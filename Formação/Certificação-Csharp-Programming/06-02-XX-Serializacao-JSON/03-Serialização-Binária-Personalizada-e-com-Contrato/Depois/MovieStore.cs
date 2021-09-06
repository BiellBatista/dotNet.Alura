using System.Collections.Generic;
using System.Xml.Serialization;

namespace _06_02_XX_Serializacao_JSON.Depois
{
    public class MovieStore3
    {
        public List<Director3> Directors = new List<Director3>();
        public List<Movie3> Movies = new List<Movie3>();

        public static MovieStore3 AddMovie(Movie3 movie)
        {
            MovieStore3 store = new MovieStore3();
            // ...
            return store;
        }
    }

    public class Director3
    {
        public string Name { get; set; }

        [XmlIgnore]
        public int NumberOfMovies;
    }

    public class Movie3
    {
        public Director3 Director { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}