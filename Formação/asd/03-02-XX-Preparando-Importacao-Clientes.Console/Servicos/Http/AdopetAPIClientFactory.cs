using System.Net.Http.Headers;

namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Servicos.Http;

public class AdopetAPIClientFactory : IHttpClientFactory
{
    private string url = "http://localhost:5057";

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