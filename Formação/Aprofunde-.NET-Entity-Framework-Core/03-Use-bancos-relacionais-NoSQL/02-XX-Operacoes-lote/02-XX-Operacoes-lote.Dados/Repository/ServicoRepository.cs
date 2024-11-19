using _02_XX_Operacoes_lote.Dados.Repository.Base;
using _02_XX_Operacoes_lote.Dados.Repository.Interfaces;
using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.Dados.Repository;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(FreelandoContext context) : base(context)
    {
    }
}