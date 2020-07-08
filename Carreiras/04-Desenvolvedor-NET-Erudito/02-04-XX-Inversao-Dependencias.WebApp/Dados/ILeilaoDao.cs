using _02_04_XX_Inversao_Dependencias.WebApp.Models;
using System.Collections.Generic;

namespace _02_04_XX_Inversao_Dependencias.WebApp.Dados
{
    public interface ILeilaoDao
    {
        Leilao BuscarLeilaoPorId(int id);
        IEnumerable<Leilao> BuscarTodosLeiloes();
        IEnumerable<Categoria> BuscarTodasCategorias();
        void Incluir(Leilao leilao);
        void Alterar(Leilao leilao);
        void Excluir(Leilao leilao);
    }
}
