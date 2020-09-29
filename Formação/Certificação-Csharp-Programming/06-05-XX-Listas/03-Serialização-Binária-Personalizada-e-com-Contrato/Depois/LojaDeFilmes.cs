using System;
using System.Collections.Generic;

namespace _06_05_XX_Listas.Depois
{
    [Serializable]
    public class LojaDeFilmes3
    {
        public List<Diretor3> Diretores = new List<Diretor3>();
        public List<Filme3> Filmes = new List<Filme3>();
        public static void AdicionarFilme(Filme3 filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [Serializable]
    public class Diretor3
    {
        public string Nome { get; set; }
        [NonSerialized]
        public int NumeroFilmes;
    }

    [Serializable]
    public class Filme3
    {
        public Diretor3 Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}
