using _03_04_XX_Entendendo_OCP.Console.Modelos;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace _03_04_XX_Entendendo_OCP.Console.Servicos.Http;

public class ClienteService : IApiService<Cliente>
{
    private HttpClient client;

    public ClienteService(HttpClient client)
    {
        this.client = client;
    }

    public Task CreateAsync(Cliente cliente)
    {
        return client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }
}