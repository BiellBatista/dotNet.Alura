namespace _05_05_Camada_anticorrupcao.Clientes.Cadastro;

public interface IAcessoManager
{
    Task AdicionarClienteAsync(string email, CancellationToken cancellationToken);

    Task RemoverClienteAsync(string email, CancellationToken cancellationToken);

    Task<bool?> ClientePossuiAcessoAsync(string email, CancellationToken cancellationToken);

    Task BloquearClienteAsync(string email, CancellationToken cancellationToken);
}