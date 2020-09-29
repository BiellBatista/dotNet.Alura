using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _06_05_XX_Listas.Depois
{
    [DataContract]
    public class LojaDeFilmes4
    {
        [DataMember]
        public List<Diretor4> Diretores = new List<Diretor4>();
        [DataMember] public List<Filme4> Filmes = new List<Filme4>();

        public static void AdicionarFilme(Filme4 filme)
        {
            // Aqui vai a lógica de inserção de filme...
        }
    }

    [DataContract]
    public class Diretor4
    {
        [DataMember]
        public string Nome { get; set; }
        [IgnoreDataMember]
        public int NumeroFilmes;
    }

    [DataContract]
    public class Filme4
    {
        [DataMember]
        public Diretor4 Diretor { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Ano { get; set; }
    }
}
