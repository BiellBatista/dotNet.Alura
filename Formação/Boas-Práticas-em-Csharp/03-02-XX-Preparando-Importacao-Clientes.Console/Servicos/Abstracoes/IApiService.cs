namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T obj);

    Task<IEnumerable<T>?> ListAsync();
}