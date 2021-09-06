using System.Collections.Generic;

namespace _06_03_XX_Serializacao_Binaria_Personalizada_Contrato.Antes
{
    public class LojaDeFilmes4
    {
        public List<Diretor4> Diretores = new List<Diretor4>();
        public List<Filme4> Filmes = new List<Filme4>();

        public static void AdicionarFilme(Filme4 filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    public class Diretor4
    {
        public string Nome { get; set; }
        public int NumeroFilmes;
    }

    public class Filme4
    {
        public Diretor4 Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}