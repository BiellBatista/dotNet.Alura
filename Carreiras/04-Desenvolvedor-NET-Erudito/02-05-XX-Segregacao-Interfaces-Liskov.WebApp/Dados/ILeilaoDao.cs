using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;
using System.Collections.Generic;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados
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
