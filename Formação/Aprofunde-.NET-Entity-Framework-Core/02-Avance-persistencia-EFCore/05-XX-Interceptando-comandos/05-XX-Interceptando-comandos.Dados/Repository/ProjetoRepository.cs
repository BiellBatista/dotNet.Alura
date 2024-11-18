using _05_XX_Interceptando_comandos.Dados.Repository.Base;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
{
    public ProjetoRepository(FreelandoContext context) : base(context)
    {
    }
}