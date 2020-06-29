using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class ListandoDocumentos
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
            Console.WriteLine("Listando Documentos");

            //buscando documentos, sem critério
            var listaLivros = await conexaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}
