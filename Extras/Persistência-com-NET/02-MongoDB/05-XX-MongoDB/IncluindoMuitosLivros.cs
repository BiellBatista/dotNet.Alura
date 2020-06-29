using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05_XX_MongoDB
{
    class IncluindoMuitosLivros
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

            //criando vários documentos que serão inseridos na base de dados
            List<Livro> Livros = new List<Livro>();
            Livros.Add(ValoresLivro.incluiValoresLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"));
            Livros.Add(ValoresLivro.incluiValoresLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"));
            Livros.Add(ValoresLivro.incluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação"));

            await conexaoBiblioteca.Livros.InsertManyAsync(Livros);

            Console.WriteLine("Documentos Incluídos");
        }
    }
}
