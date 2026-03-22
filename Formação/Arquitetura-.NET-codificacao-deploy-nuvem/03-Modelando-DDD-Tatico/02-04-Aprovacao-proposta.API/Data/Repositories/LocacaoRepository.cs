using _02_04_Aprovacao_proposta.API.Data;
using _02_04_Aprovacao_proposta.Vendas.Locacoes;

namespace _02_04_Aprovacao_proposta.API.Data.Repositories;

public class LocacaoRepository(AppDbContext context) : BaseRepository<Locacao>(context)
{
}