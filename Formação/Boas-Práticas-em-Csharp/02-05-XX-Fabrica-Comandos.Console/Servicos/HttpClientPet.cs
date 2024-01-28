using _05_XX_Fabrica_Comandos.Console.Modelos;
using System.Net.Http.Json;

namespace _05_XX_Fabrica_Comandos.Console.Servicos
{
    public class HttpClientPet
    {
        private HttpClient client;

        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }

        public virtual Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}