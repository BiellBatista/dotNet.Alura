using System;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class UsandoValoresLivros
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
            //criando livros para serem inseridos no banco
            Livro Livro = new Livro();
            Livro = ValoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura  Brasileira");
            await conexaoBiblioteca.Livros.InsertOneAsync(Livro);

            Livro Livro2 = new Livro();
            Livro2 = ValoresLivro.incluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await conexaoBiblioteca.Livros.InsertOneAsync(Livro2);

            Console.WriteLine("Documento Incluído");
        }
    }
}
