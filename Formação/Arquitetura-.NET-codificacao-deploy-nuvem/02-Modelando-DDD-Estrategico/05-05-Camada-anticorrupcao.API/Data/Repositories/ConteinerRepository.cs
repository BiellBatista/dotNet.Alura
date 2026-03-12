using _05_05_Camada_anticorrupcao.Engenharia.Conteineres;

namespace _05_05_Camada_anticorrupcao.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}