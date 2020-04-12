using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_05_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels
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
