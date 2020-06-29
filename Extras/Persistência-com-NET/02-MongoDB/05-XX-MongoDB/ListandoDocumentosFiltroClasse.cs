using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class ListandoDocumentosFiltroClasse
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
            //dentro da coleção livros, me retorne os com autor "Machado de Assis"
            //var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");
            //dentro da coleção livros, me retorne os com o ano maior ou igual a 1999"
            //var condicao = construtor.Gte(x => x.Ano, 1999);
            //dentro da coleção livros, me retorne os com o ano maior ou igual a 1999 e que tenham mais ou igual de 300 páginas"
            //var condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);
            //dentro da coleção livros, me retorne de assunto ficção cientifica"
            var condicao = construtor.AnyEq(x => x.Assuntos, "Ficção Científica");

            //buscando documentos, com critério
            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}
