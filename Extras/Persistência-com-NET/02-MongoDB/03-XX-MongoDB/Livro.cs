using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _03_XX_MongoDB
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
}
