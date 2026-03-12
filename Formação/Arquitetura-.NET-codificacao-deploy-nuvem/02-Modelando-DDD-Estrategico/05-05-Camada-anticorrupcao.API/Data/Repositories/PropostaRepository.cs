using _05_05_Camada_anticorrupcao.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _05_05_Camada_anticorrupcao.API.Data.Repositories;

public class PropostaRepository(AppDbContext dbContext) : BaseRepository<Proposta>(dbContext)
{
    public override Task<Proposta?> GetFirstAsync<TProperty>(Expression<Func<Proposta, bool>> filtro, Expression<Func<Proposta, TProperty>> orderBy, CancellationToken cancellationToken = default)
    {
        return dbContext.Propostas
            .Include(p => p.Comentarios)
            .Include(p => p.Solicitacao)
            .AsNoTracking()
            .OrderBy(orderBy)
            .FirstOrDefaultAsync(filtro, cancellationToken);
    }
}