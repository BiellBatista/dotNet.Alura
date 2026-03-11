using _05_03_Separando_contexto_clientes.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _05_03_Separando_contexto_clientes.API.Data.Repositories;

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