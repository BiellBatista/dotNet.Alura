using _01_Apresentando_ContainRs.API.Domain;

namespace _01_Apresentando_ContainRs.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}