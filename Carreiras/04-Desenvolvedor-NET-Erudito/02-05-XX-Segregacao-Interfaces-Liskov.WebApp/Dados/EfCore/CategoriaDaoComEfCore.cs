using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados.EfCore
{
    public class CategoriaDaoComEfCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoComEfCore(AppDbContext context)
        {
            _context = context;
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}

/**
 * Não posso deixar de cumprir (preencher) os métodos da interface...
 * Ou seja, não posso ter throw new System.NotImplementedException();
 * Devo ter coesão nas interfaces. Neste caso, criei uma interface de leitura e outra de escrita (CQRS)
 */
