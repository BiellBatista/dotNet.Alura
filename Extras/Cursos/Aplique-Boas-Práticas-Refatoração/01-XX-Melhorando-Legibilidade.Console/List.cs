using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace _01_XX_Melhorando_Legibilidade.Console;

internal class List
{
    private HttpClient client;

    public List()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
    }

    public async Task ListaDadosPetsDaAPIAsync()
    {
        IEnumerable<Pet>? pets = await ListPetsAsync();
        
        System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
        
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);

        return _client;
    }

    private async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}