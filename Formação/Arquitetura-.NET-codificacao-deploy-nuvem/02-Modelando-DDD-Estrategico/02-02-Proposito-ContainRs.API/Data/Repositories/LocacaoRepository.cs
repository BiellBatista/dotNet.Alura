using _02_02_Proposito_ContainRs.API.Domain;

namespace _02_02_Proposito_ContainRs.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}