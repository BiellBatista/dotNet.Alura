namespace _09_06_XX_Rastreamento_Aplicacoes.Antes
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