using _02_03_Identificando_areas_funcionais.API.Domain;

namespace _02_03_Identificando_areas_funcionais.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}