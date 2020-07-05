using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class ManipulandoClassesExternas
    {
        static void Main(string[] args)
        {
            Task T = MainSync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //inicializar uma variavel do tipo objeto Livro
            Livro livro = new Livro();
            livro.Titulo = "Star Wars Legends";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Paginas = 245;
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Ficção Científica");
            Lista_Assuntos.Add("Ação");
            livro.Assuntos = Lista_Assuntos;

            //acesso ao servidor do MongoDB
            var conexaoBiblioteca = new ConectandoMongoDB();

            //incluindo documento
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento Incluído");
        }
    }
}
