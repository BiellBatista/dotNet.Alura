namespace _09_08_XX_Contadores_Desempenho.Depois
{
    public class Filme
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }

        public Filme(string diretor, string titulo)
        {
            Diretor = diretor;
            Titulo = titulo;
        }
    }
}