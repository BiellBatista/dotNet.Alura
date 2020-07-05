using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class ListandoDocumentosOrdem
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
            Console.WriteLine("Listando Documentos com Filtro Complexo");

            var construtor = Builders<Livro>.Filter;
            //dentro da coleção livros, me retorne os que tiverem mais de 100 páginas"
            var condicao = construtor.Gt(x => x.Paginas, 100);

            //buscando documentos, com critério. Ordernando pelo título e pegando os 5 primeiros
            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).Limit(5).ToListAsync();

            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}
