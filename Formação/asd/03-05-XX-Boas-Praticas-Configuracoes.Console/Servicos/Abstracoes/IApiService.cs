namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;

public interface IApiService<T>
{
    Task CreateAsync(T obj);

    Task<IEnumerable<T>?> ListAsync();
}