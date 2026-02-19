using _04_02_Linguagens_consistentes.API.Domain;

namespace _04_02_Linguagens_consistentes.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}