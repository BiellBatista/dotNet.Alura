using System.Collections.Generic;
using System.Xml.Serialization;

namespace _06_04_XX_Arrays.Depois
{
    public class MovieStore4
    {
        public List<Director4> Directors = new List<Director4>();
        public List<Movie4> Movies = new List<Movie4>();

        public static MovieStore4 AddMovie(Movie4 movie)
        {
            MovieStore4 store = new MovieStore4();
            // ...
            return store;
        }
    }

    public class Director4
    {
        public string Name { get; set; }
        [XmlIgnore]
        public int NumberOfMovies;
    }

    public class Movie4
    {
        public Director4 Director { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}
