using _04_06_Interacoes_entre_componentes.Domain.Models;

namespace _04_06_Interacoes_entre_componentes.Application.Repositories;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);
}
