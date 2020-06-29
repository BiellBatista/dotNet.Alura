using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _05_XX_MongoDB
{
    public class Livro
    {
        //falando que o Id, no banco, será do tipo ObjectId
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assuntos { get; set; }
    }

    public class ValoresLivro
    {

        public static Livro incluiValoresLivro(string titulo, string autor, int ano, int paginas, string assuntos)
        {
            Livro Livro = new Livro();
            Livro.Titulo = titulo;
            Livro.Autor = autor;
            Livro.Ano = ano;
            Livro.Paginas = paginas;
            string[] vetAssunto = assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();

            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }

            Livro.Assuntos = vetAssunto2;
            return Livro;
        }
    }
}
