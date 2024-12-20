﻿using _07_Simulando_cancelamento.Console.Modelos;
using System.Net.Http.Json;

namespace _07_Simulando_cancelamento.Console.Client;

public sealed class JornadaMilhasClient(HttpClient client)
{
    public async Task<IEnumerable<Voo>?> ConsultarVoosAsync(CancellationToken token = default)
    {
        HttpResponseMessage response = await client.GetAsync("/Voos", token);

        return await response.Content.ReadFromJsonAsync<IEnumerable<Voo>>();
    }

    public async Task<string?> ComprarPassagemAsync(CompraPassagemRequest request) =>
        await client.PostAsJsonAsync("/Voos/comprar", request).Result.Content.ReadFromJsonAsync<string>();
}