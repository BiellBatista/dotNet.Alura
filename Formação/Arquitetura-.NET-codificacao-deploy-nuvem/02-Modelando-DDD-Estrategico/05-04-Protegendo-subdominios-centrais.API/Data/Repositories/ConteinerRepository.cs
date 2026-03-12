using _05_04_Protegendo_subdominios_centrais.API.Domain;

namespace _05_04_Protegendo_subdominios_centrais.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}