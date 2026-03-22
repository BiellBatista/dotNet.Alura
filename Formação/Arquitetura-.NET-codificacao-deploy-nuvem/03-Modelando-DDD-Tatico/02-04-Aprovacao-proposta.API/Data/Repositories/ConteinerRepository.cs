using _02_04_Aprovacao_proposta.API.Data;
using _02_04_Aprovacao_proposta.Engenharia.Conteineres;

namespace _02_04_Aprovacao_proposta.API.Data.Repositories;

public class ConteinerRepository : BaseRepository<Conteiner>
{
    public ConteinerRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}