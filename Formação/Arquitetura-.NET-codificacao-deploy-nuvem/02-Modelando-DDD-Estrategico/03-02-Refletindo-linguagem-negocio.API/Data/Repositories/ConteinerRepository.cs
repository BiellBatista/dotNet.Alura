using _03_02_Refletindo_linguagem_negocio.API.Domain;

namespace _03_02_Refletindo_linguagem_negocio.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}