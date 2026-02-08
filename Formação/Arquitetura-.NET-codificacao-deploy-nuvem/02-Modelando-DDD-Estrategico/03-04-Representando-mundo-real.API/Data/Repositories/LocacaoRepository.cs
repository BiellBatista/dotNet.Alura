using _03_04_Representando_mundo_real.API.Domain;

namespace _03_04_Representando_mundo_real.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}