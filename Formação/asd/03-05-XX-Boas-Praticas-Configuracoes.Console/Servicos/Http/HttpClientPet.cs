using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;

public class HttpClientPet : IApiService<Pet>
{
    private HttpClient client;

    public HttpClientPet(HttpClient client)
    {
        this.client = client;
    }

    public virtual Task CreateAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}