namespace _09_07_XX_Gravando_Mensagens_Event_Log.Antes
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