using _05_XX_Interceptando_comandos.Dados.Repository.Base;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class CandidaturaRepository : Repository<Candidatura>, ICandidaturaRepository
{
    public CandidaturaRepository(FreelandoContext context) : base(context)
    {
    }
}