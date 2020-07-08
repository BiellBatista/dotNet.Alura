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

        public void Alterar(Categoria obj)
        {
            throw new System.NotImplementedException();
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

        public void Excluir(Categoria obj)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Categoria obj)
        {
            throw new System.NotImplementedException();
        }
    }
}

/**
 * Não posso deixar de cumprir (preencher) os métodos da interface...
 * Ou seja, não posso ter throw new System.NotImplementedException();
 */
