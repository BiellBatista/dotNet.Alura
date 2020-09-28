using System.Collections.Generic;

namespace _06_01_XX_Serializacao_XML.Antes
{
    public class LojaDeFilmes5
    {
        public List<Diretor5> Diretores = new List<Diretor5>();
        public List<Filme5> Filmes = new List<Filme5>();

        public static void AdicionarFilme(Filme5 filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    public class Diretor5
    {
        public string Nome { get; set; }
        public int NumeroFilmes;
    }

    public class Filme5
    {
        public Diretor5 Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}
