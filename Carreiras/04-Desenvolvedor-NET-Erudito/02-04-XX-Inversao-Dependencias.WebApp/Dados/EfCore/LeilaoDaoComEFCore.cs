using System.Collections.Generic;
using _02_04_XX_Inversao_Dependencias.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_04_XX_Inversao_Dependencias.WebApp.Dados.EfCore
{
    public class LeilaoDaoComEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public IEnumerable<Leilao> BuscarTodosLeiloes() => _context.Leiloes.Include(l => l.Categoria);

        public IEnumerable<Categoria> BuscarTodasCategorias() => _context.Categorias;

        public void IncluirLeilao(Leilao obj)
        {
            _context.Leiloes.Add(obj);
            _context.SaveChanges();
        }

        public void AlterarLeilao(Leilao obj)
        {
            _context.Leiloes.Update(obj);
            _context.SaveChanges();
        }

        public void ExcluirLeilao(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
