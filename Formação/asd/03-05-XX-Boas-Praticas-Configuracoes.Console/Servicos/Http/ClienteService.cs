using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;

public class ClienteService : IApiService<Cliente>
{
    private readonly HttpClient httpClient;

    public ClienteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task CreateAsync(Cliente obj)
    {
        return httpClient.PostAsJsonAsync("cliente/add", obj);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>?>();
    }
}