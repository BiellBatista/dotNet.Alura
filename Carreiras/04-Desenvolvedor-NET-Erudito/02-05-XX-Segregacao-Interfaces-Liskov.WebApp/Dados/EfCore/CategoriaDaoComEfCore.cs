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
 * 
 * Devo cumprir 100% o contrato da interface
 * 
 * Começamos a aula criando uma nova abstração IDao que subia um nível de abstração e garantia que todos os DAOs tivessem o mesmo comportamento. Contudo tivemos que relaxar a implementação dos métodos Incluir(), Alterar() e Excluir() de CategoriaDaoComEfCore porque o sistema não tinha casos de uso para isso. Barbara Liskov havia estudado o recurso de heranças em OO e reparou que hierarquias problemáticas eram aquelas onde os tipos descendentes não conseguiam ser substituídos plenamente por seus ancestrais. Robert Martin trouxe essa idéia para a letra L homenageando Barbara: surgia o Princípio da Substituição de Liskov (LSP). Robert aumentou a idéia para abranger qualquer abstração. Podemos então afirmar: faça com que todas as implementações cumpram as promessas de suas abstrações.
 */
