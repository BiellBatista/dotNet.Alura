using _05_03_Separando_contexto_clientes.Vendas.Locacoes;

namespace _05_03_Separando_contexto_clientes.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}