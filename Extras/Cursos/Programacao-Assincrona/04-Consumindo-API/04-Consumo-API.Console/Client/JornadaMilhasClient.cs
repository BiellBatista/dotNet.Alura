﻿using _04_Consumo_API.Console.Modelos;
using System.Net.Http.Json;

namespace _04_Consumo_API.Console.Client;

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