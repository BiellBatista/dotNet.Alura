using _05_05_Camada_anticorrupcao.Vendas.Locacoes;

namespace _05_05_Camada_anticorrupcao.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}