using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace _03_01_XX_Importando_Json.Console.Servicos.Http;

public class HttpClientPet : IApiService
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