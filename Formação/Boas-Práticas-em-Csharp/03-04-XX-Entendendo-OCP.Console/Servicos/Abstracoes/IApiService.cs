namespace _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T obj);

    Task<IEnumerable<T>?> ListAsync();
}