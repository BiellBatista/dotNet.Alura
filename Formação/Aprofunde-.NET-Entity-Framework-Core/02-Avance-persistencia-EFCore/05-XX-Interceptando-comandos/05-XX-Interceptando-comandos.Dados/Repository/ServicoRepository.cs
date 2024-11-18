using _05_XX_Interceptando_comandos.Dados.Repository.Base;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(FreelandoContext context) : base(context)
    {
    }
}