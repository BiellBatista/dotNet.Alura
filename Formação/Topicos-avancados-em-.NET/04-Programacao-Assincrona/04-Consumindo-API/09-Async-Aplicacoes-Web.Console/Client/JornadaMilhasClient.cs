﻿using _09_Async_Aplicacoes_Web.Console.Modelos;
using System.Net.Http.Json;

namespace _09_Async_Aplicacoes_Web.Console.Client;

public sealed class JornadaMilhasClient(HttpClient client)
{
    public async Task<IEnumerable<Voo>?> ConsultarVoosAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/Voos");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Voo>>();
    }

    public async Task<string?> ComprarPassagemAsync(CompraPassagemRequest request) =>
        await client.PostAsJsonAsync("/Voos/comprar", request).Result.Content.ReadFromJsonAsync<string>();
}