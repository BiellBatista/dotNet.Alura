using _05_02_Nem_todo_contexto_ilha.Vendas.Locacoes;

namespace _05_02_Nem_todo_contexto_ilha.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}