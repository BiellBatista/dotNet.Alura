using _05_XX_Interceptando_comandos.Dados.Repository.Base;
using _05_XX_Interceptando_comandos.Dados.Repository.Interfaces;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
{
    public EspecialidadeRepository(FreelandoContext context) : base(context)
    {
    }
}