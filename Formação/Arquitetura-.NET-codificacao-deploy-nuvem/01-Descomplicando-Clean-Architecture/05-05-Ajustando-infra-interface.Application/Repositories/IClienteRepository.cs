namespace _05_05_Ajustando_infra_interface.Application.Repositories;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);

    Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>>? filtro = default);
}