using _05_04_Implementando_caso_uso.Domain.Models;
using System.Linq.Expressions;

namespace _05_04_Implementando_caso_uso.Application.Repositories;

public interface IClienteRepository
{
    Task<Cliente> AddAsync(Cliente cliente);
    Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>>? filtro = default);
}
