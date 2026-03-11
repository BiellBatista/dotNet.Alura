using _05_03_Separando_contexto_clientes.API.Domain;

namespace _05_03_Separando_contexto_clientes.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}