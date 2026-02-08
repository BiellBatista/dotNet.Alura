using _02_02_Proposito_ContainRs.API.Domain;

namespace _02_02_Proposito_ContainRs.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}