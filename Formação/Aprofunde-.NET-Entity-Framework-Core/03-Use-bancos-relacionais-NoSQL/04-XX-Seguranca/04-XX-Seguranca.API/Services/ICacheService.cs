namespace _04_XX_Seguranca.API.Services;

public interface ICacheService
{
    Task<T> GetCachedDataAsync<T>(string key);

    Task SetCachedDataAsync<T>(string key, T data, TimeSpan expiration);

    Task RemoveCachedDataAsync(string key);
}