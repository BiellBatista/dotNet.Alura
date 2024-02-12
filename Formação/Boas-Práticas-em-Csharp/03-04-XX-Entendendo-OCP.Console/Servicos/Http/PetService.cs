using _03_04_XX_Entendendo_OCP.Console.Modelos;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace _03_04_XX_Entendendo_OCP.Console.Servicos.Http;

public class PetService : IApiService<Pet>
{
    private HttpClient client;

    public PetService(HttpClient client)
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