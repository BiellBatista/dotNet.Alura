using _04_04_Comunicacao_entre_componentes.Domain.Models;

namespace _04_04_Comunicacao_entre_componentes.Application.Repositories;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);
}
