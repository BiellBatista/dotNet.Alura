using _04_02_Linguagens_consistentes.API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _04_02_Linguagens_consistentes.API.Data.Repositories;

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