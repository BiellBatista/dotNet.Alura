using _05_04_Implementando_caso_uso.Application.Repositories;
using _05_04_Implementando_caso_uso.Domain.Models;

namespace _05_04_Implementando_caso_uso.Application.UseCases;

public class ConsultarClientes
{
    private readonly IClienteRepository repository;

    public ConsultarClientes(UnidadeFederativa? estado, IClienteRepository repository)
    {
        Estado = estado;
        this.repository = repository;
    }

    public UnidadeFederativa? Estado { get; }

    public Task<IEnumerable<Cliente>> ExecutarAsync()
    {
        if (Estado is not null)
        {
            return repository.GetAsync(c => c.Estado == Estado);
        }
        return repository.GetAsync();
    }
}