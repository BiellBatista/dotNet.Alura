using _05_03_Consultando_clientes_estado.Application.Repositories;
using _05_03_Consultando_clientes_estado.Domain.Models;

namespace _05_03_Consultando_clientes_estado.Application.UseCases;

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

    }
}
