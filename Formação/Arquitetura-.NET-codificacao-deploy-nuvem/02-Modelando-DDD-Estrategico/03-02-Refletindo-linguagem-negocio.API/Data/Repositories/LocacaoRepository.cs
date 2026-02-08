using _03_02_Refletindo_linguagem_negocio.API.Domain;

namespace _03_02_Refletindo_linguagem_negocio.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}