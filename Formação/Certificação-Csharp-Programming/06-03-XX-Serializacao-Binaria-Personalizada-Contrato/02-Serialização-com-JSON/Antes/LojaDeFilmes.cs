using System.Collections.Generic;

namespace _06_03_XX_Serializacao_Binaria_Personalizada_Contrato.Antes
{
    public class LojaDeFilmes2
    {
        public List<Diretor> Diretores = new List<Diretor>();
        public List<Filme> Filmes = new List<Filme>();

        public static void AdicionarFilme(Filme filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    public class Diretor2
    {
        public string Nome { get; set; }
        public int NumeroFilmes;
    }

    public class Filme2
    {
        public Diretor Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}