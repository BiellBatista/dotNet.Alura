using _02_XX_Operacoes_lote.Dados.Repository.Base;
using _02_XX_Operacoes_lote.Dados.Repository.Interfaces;
using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.Dados.Repository;

public class ContratoRepository : Repository<Contrato>, IContratoRepository
{
    public ContratoRepository(FreelandoContext context) : base(context)
    {
    }
}