using System.Net.Http.Headers;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;

public class AdopetAPIClientFactory : IHttpClientFactory
{
    private readonly string url;

    public AdopetAPIClientFactory(string url)
    {
        this.url = url;
    }

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}