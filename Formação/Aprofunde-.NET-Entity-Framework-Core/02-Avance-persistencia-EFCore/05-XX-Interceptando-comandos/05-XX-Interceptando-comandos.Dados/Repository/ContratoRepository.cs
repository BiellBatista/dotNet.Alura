using _05_XX_Interceptando_comandos.Dados.Repository.Base;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class ContratoRepository : Repository<Contrato>, IContratoRepository
{
    public ContratoRepository(FreelandoContext context) : base(context)
    {
    }
}