using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _02_04_XX_Principio_Aberto_Fechado.WebApp.Models;

namespace _02_04_XX_Principio_Aberto_Fechado.WebApp.Dados.EfCore
{
    public class CategoriaDaoComEfCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoComEfCore(AppDbContext context)
        {
            _context = context;
        }

        public Categoria ConsultaCategoriaPorId(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}
