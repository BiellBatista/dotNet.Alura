using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class ExcluindoDocumento
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
            Console.WriteLine("Deletando livros de M. Assis");

            var construtor = Builders<Livro>.Filter;
            //dentro da coleção livros, me retorne os que de titulo "Guerra dos Tronos""
            var condicao = construtor.Eq(x => x.Autor, "M. Assis");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Excluindo livros");
            //apagandi vários livros que atendam a condição
            await conexaoBiblioteca.Livros.DeleteManyAsync(condicao);
            Console.WriteLine("Fim");
        }
    }
}
