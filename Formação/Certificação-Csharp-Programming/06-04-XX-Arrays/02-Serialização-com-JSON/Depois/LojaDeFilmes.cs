using Newtonsoft.Json;
using System.Collections.Generic;

namespace _06_04_XX_Arrays.Depois
{
    [JsonObject("MovieStore")]
    public class LojaDeFilmes2
    {
        [JsonProperty("Directors")]
        public List<Diretor> Diretores = new List<Diretor>();
        [JsonProperty("Movies")]
        public List<Filme> Filmes = new List<Filme>();

        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [JsonObject("Director")]
    public class Diretor2
    {
        [JsonProperty("Name")]
        public string Nome { get; set; }
        [JsonIgnore]
        public int NumeroFilmes;
    }

    [JsonObject("Movie")]
    public class Filme2
    {
        [JsonProperty("Director")]
        public Diretor Diretor { get; set; }
        [JsonProperty("Title")]
        public string Titulo { get; set; }
        [JsonProperty("Year")]
        public string Ano { get; set; }
    }
}
