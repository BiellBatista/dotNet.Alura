using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace _03_XX_MongoDB
{
    class ManipulandoClasses
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

            livro.Titulo = "Sob a redoma";
            livro.Autor = "Stephen King";
            livro.Ano = 2012;
            livro.Paginas = 679;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção Científica");
            listaAssuntos.Add("Terror");
            listaAssuntos.Add("Ação");
            livro.Assuntos = listaAssuntos;

            //acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso a coleção
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //incluindo documento
            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento Incluído");
        }
    }
}
