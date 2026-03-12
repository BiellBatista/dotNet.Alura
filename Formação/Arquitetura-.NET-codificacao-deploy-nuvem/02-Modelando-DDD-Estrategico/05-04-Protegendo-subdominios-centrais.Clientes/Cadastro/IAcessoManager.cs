namespace _05_04_Protegendo_subdominios_centrais.Clientes.Cadastro;

public interface IAcessoManager
{
    Task AdicionarClienteAsync(string email, CancellationToken cancellationToken);

    Task RemoverClienteAsync(string email, CancellationToken cancellationToken);

    Task<bool?> ClientePossuiAcessoAsync(string email, CancellationToken cancellationToken);

    Task BloquearClienteAsync(string email, CancellationToken cancellationToken);
}