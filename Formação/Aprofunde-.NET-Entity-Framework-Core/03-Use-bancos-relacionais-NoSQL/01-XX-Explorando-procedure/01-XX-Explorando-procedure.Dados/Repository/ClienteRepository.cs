using _01_XX_Explorando_procedure.Dados.Repository.Base;
using _01_XX_Explorando_procedure.Dados.Repository.Interfaces;
using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.Dados.Repository;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(FreelandoContext context) : base(context)
    {
    }
}