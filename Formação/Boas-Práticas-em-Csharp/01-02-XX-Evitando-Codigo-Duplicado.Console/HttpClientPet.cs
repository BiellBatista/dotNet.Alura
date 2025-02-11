﻿using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace _01_02_XX_Evitando_Codigo_Duplicado.Console;

internal class HttpClientPet
{
    private HttpClient client;

    public HttpClientPet()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);

        return _client;
    }

    public Task CreatePetAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}