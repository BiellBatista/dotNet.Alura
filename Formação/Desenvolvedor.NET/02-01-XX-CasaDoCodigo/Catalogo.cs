using System.Collections.Generic;

namespace _02_01_XX_CasaDoCodigo
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Quem mexeu na minha query?", 12.99m));
            livros.Add(new Livro("002", "Fique com o C#", 30.99m));
            livros.Add(new Livro("003", "Java para Baixinhos", 25.99m));

            return livros;
        }
    }
}
