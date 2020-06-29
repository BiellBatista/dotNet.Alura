using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class AlterandoDocumento
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
            Console.WriteLine("Listar o livro Guerra dos Tronos");

            var construtor = Builders<Livro>.Filter;
            //dentro da coleção livros, me retorne os que de titulo "Guerra dos Tronos""
            var condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());

                //alterando os atributos
                livro.Ano = 2000;
                livro.Paginas = 900;
                //alterando o documento na base de dados
                await conexaoBiblioteca.Livros.ReplaceOneAsync(condicao, livro);
            }

            Console.WriteLine("Fim");
        }
    }
}
