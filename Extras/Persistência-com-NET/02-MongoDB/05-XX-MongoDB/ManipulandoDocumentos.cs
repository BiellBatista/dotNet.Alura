using System;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace _05_XX_MongoDB
{
    class ManipulandoDocumentos
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
        }
    }
}
