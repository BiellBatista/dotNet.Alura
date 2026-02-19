using _04_06_Evitando_ambiguidades.API.Domain;

namespace _04_06_Evitando_ambiguidades.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}