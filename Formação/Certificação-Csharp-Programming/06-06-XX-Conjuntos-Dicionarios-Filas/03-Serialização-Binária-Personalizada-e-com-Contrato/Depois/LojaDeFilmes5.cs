using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _06_06_XX_Conjuntos_Dicionarios_Filas.Depois
{
    [Serializable]
    public class LojaDeFilmes5
    {
        public List<Diretor5> Diretores = new List<Diretor5>();
        public List<Filme5> Filmes = new List<Filme5>();

        public static void AdicionarFilme(Filme5 filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [Serializable]
    public class Diretor5 : ISerializable
    {
        public string Nome { get; set; }
        public int NumeroFilmes;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Nome), Nome);
            info.AddValue(nameof(NumeroFilmes), NumeroFilmes);
            info.AddValue("Resumo", $"Nome: {Nome}, Número de Filmes: {NumeroFilmes}");
        }
    }

    [Serializable]
    public class Filme5
    {
        public Diretor5 Diretor { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
    }
}