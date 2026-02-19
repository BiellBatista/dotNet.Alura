using _04_06_Evitando_ambiguidades.API.Domain;

namespace _04_06_Evitando_ambiguidades.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}