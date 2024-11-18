using _05_XX_Interceptando_comandos.Dados.Repository.Base;
using _05_XX_Interceptando_comandos.Dados.Repository.Interfaces;

namespace _05_XX_Interceptando_comandos.Dados.Repository;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(FreelandoContext context) : base(context)
    {
    }
}