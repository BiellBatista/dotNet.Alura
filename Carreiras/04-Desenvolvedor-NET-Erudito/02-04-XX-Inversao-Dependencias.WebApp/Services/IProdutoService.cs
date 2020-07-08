using _02_04_XX_Inversao_Dependencias.WebApp.Models;
using System.Collections.Generic;

namespace _02_04_XX_Inversao_Dependencias.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);
        IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();
        Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);
    }
}
