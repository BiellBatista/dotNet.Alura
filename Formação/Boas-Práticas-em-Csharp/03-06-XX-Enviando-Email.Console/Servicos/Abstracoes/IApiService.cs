namespace _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T obj);

    Task<IEnumerable<T>?> ListAsync();
}