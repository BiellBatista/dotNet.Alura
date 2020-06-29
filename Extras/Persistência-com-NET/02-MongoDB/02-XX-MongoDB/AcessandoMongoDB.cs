using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace _02_XX_MongoDB
{
    class AcessandoMongoDB
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //criando um documento com um atributo
            var doc = new BsonDocument
            {
                {"Título","Guerra dos Tronos" }
            };
            //adicionando novos atributos
            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);
            //criando um atributo do tipo array
            var assuntosArray = new BsonArray();
            assuntosArray.Add("Fantasia");
            assuntosArray.Add("Ação");
            //adicionando um novo atributo array
            doc.Add("Assuntos", assuntosArray);

            Console.WriteLine(doc);

            //acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso a coleção
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("Livros");

            //incluindo documento
            await colecao.InsertOneAsync(doc);

            Console.WriteLine("Documento Incluído");
        }
    }
}
