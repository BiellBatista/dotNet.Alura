using _03_03_Usando_glossario_fonte.API.Domain;

namespace _03_03_Usando_glossario_fonte.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}