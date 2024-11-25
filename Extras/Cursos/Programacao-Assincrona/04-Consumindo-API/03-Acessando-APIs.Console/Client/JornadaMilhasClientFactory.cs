namespace _03_Acessando_APIs.Console.Client;

public sealed class JornadaMilhasClientFactory : IHttpClientFactory
{
    private const string MediaType = "application/json";
    private const string URL = "http://localhost:5125";

    public HttpClient CreateClient(string name)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(URL),
        };

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new(MediaType));

        return client;
    }
}