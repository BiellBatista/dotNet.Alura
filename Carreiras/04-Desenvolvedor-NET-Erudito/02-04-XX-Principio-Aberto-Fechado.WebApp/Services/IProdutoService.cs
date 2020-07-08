using _02_04_XX_Principio_Aberto_Fechado.WebApp.Models;
using System.Collections.Generic;

namespace _02_04_XX_Principio_Aberto_Fechado.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);
        IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();
        Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);
    }
}
