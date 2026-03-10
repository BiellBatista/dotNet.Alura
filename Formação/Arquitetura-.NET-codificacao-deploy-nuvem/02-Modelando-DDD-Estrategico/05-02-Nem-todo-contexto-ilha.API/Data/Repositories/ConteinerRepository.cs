using _05_02_Nem_todo_contexto_ilha.API.Domain;

namespace _05_02_Nem_todo_contexto_ilha.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}