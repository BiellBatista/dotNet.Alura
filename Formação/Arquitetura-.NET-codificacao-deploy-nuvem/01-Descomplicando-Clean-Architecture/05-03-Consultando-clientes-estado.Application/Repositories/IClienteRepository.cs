using _05_03_Consultando_clientes_estado.Domain.Models;

namespace _05_03_Consultando_clientes_estado.Application.Repositories;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);
}
