using _04_02_Linguagens_consistentes.API.Domain;

namespace _04_02_Linguagens_consistentes.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}