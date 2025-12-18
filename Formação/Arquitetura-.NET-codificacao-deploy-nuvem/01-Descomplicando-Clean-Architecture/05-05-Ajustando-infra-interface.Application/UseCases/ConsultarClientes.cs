using _05_05_Ajustando_infra_interface.Application.Repositories;

namespace _05_05_Ajustando_infra_interface.Application.UseCases;

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