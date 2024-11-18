using _05_XX_Interceptando_comandos.Dados.Repository.Base;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
{
    public ProfissionalRepository(FreelandoContext context) : base(context)
    {
    }
}