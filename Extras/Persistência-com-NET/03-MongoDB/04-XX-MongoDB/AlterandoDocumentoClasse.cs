using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace _04_XX_MongoDB
{
    class AlterandoDocumentoClasse
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

            //var construtor = Builders<Livro>.Filter;
            ////dentro da coleção livros, me retorne os que de titulo "Guerra dos Tronos""
            //var condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            //var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            //foreach (var livro in listaLivros)
            //{
            //    Console.WriteLine(livro.ToJson<Livro>());
            //}

            //Console.WriteLine("Novos registros, após as alterações");
            ////objeto que irá atualizar os registros
            ////esta é outra forma, a primeira vc pode ver em AlterandoDocumento
            //var construtorAlteracao = Builders<Livro>.Update;
            //var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);

            //await conexaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);

            //listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            //foreach (var livro in listaLivros)
            //{
            //    Console.WriteLine(livro.ToJson<Livro>());
            //}

            var construtor = Builders<Livro>.Filter;
            //dentro da coleção livros, me retorne os que de titulo "Guerra dos Tronos""
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Novos registros, após as alterações");
            //objeto que irá atualizar os registros
            //esta é outra forma, a primeira vc pode ver em AlterandoDocumento
            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");
            //alterando vários registros, porque a condicao retorna vários registros
            await conexaoBiblioteca.Livros.UpdateManyAsync(condicao, condicaoAlteracao);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var livro in listaLivros)
            {
                Console.WriteLine(livro.ToJson<Livro>());
            }

            Console.WriteLine("Fim");
        }
    }
}
