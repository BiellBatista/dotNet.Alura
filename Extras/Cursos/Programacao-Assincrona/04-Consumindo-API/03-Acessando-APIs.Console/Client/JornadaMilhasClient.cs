using _03_Acessando_APIs.Console.Modelos;
using System.Net.Http.Json;

namespace _03_Acessando_APIs.Console.Client;

public sealed class JornadaMilhasClient(HttpClient client)
{
    public async Task<IEnumerable<Voo>?> ConsultarVoos()
    {
        HttpResponseMessage response = await client.GetAsync("/Voos");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Voo>>();
    }

    public async Task<string?> ComprarPassagem(CompraPassagemRequest request) =>
        await client.PostAsJsonAsync("/Voos/comprar", request).Result.Content.ReadFromJsonAsync<string>();
}