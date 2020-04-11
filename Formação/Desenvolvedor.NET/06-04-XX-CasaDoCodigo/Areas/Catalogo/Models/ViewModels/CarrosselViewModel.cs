using _06_04_XX_CasaDoCodigo.Models;
using System.Collections.Generic;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public CarrosselViewModel(Categoria categoria, IList<Produto> produtos, int numPaginas, int tamanhoPagina)
        {
            Categoria = categoria;
            Produtos = produtos;
            NumPaginas = numPaginas;
            TamanhoPagina = tamanhoPagina;
        }

        public Categoria Categoria { get; set; }
        public IList<Produto> Produtos { get; set; }
        public int NumPaginas { get; set; }
        public int TamanhoPagina { get; set; }
    }
}
