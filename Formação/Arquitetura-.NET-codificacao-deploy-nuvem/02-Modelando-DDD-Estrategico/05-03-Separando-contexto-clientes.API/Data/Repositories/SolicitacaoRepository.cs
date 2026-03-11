using _05_03_Separando_contexto_clientes.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _05_03_Separando_contexto_clientes.API.Data.Repositories;

public class SolicitacaoRepository(AppDbContext dbContext)
    : BaseRepository<PedidoLocacao>(dbContext)
{
    // métodos sobrescritos e específicos vão aqui
    public override Task<PedidoLocacao?> GetFirstAsync<TProperty>(Expression<Func<PedidoLocacao, bool>> filtro, Expression<Func<PedidoLocacao, TProperty>> orderBy, CancellationToken cancellationToken = default)
    {
        return dbContext.Solicitacoes
            .Include(s => s.Propostas)
            .AsNoTracking()
            .OrderBy(orderBy)
            .FirstOrDefaultAsync(filtro, cancellationToken);
    }
}