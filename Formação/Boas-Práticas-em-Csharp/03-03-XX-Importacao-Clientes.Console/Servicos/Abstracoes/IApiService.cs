namespace _03_03_XX_Importacao_Clientes.Console.Servicos.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T obj);

    Task<IEnumerable<T>?> ListAsync();
}