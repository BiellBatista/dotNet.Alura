using _02_03_XX_Inversao_Dependencias.WebApp.Models;
using System.Collections.Generic;

namespace _02_03_XX_Inversao_Dependencias.WebApp.Dados
{
    public interface ILeilaoDao
    {
        public Leilao BuscarLeilaoPorId(int id);
        public IEnumerable<Leilao> BuscarTodosLeiloes();
        public IEnumerable<Categoria> BuscarTodasCategorias();
        public void IncluirLeilao(Leilao obj);
        public void AlterarLeilao(Leilao obj);
        public void ExcluirLeilao(Leilao leilao);
    }
}
