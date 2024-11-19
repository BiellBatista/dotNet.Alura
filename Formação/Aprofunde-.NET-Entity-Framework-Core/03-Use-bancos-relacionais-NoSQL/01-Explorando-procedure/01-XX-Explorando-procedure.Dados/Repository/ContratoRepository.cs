using _01_XX_Explorando_procedure.Dados.Repository.Base;
using _01_XX_Explorando_procedure.Dados.Repository.Interfaces;
using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.Dados.Repository;

public class ContratoRepository : Repository<Contrato>, IContratoRepository
{
    public ContratoRepository(FreelandoContext context) : base(context)
    {
    }
}