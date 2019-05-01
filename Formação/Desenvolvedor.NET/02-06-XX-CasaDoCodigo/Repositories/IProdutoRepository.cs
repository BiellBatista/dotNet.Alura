using _02_06_XX_CasaDoCodigo.Models;
using System.Collections.Generic;

namespace _02_06_XX_CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}