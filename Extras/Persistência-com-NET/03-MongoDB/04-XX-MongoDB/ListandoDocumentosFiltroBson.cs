using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class ListandoDocumentosFiltroBson
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //acesso ao servidor do MongoDB
            var conexaoBiblioteca = new ConectandoMongoDB();
            Console.WriteLine("Listando Documentos com Filtro");

            var filtro = new BsonDocument { { "Autor", "Machado de Assis" } };

            //buscando documentos, com critério
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();

            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}
