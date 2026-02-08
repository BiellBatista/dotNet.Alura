using _02_03_Identificando_areas_funcionais.API.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _02_03_Identificando_areas_funcionais.API.Data.Repositories;

public class SolicitacaoRepository(AppDbContext dbContext)
    : BaseRepository<Solicitacao>(dbContext)
{
    // métodos sobrescritos e específicos vão aqui
    public override Task<Solicitacao?> GetFirstAsync<TProperty>(Expression<Func<Solicitacao, bool>> filtro, Expression<Func<Solicitacao, TProperty>> orderBy, CancellationToken cancellationToken = default)
    {
        return dbContext.Solicitacoes
            .Include(s => s.Propostas)
            .AsNoTracking()
            .OrderBy(orderBy)
            .FirstOrDefaultAsync(filtro, cancellationToken);
    }
}