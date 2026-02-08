using _01_Apresentando_ContainRs.API.Domain;

namespace _01_Apresentando_ContainRs.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}