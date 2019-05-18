using _03_05_XX_CasaDoCodigo.Models;
using System.Collections.Generic;

namespace _03_05_XX_CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}