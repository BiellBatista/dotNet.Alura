using System.Collections.Generic;

namespace _04_06_XX_CasaDoCodigo.Models.ViewModels
{
    public class BuscaProdutosViewModel
    {
        public BuscaProdutosViewModel(IList<Produto> produtos, string pesquisa)
        {
            Produtos = produtos;
            Pesquisa = pesquisa;
        }

        public IList<Produto> Produtos { get; }
        public string Pesquisa { get; set; }
    }
}
