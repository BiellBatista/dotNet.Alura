﻿using _03_05_XX_Deploy_Azure.Web.Requests;
using _03_05_XX_Deploy_Azure.Web.Response;

namespace _03_05_XX_Deploy_Azure.Web.Services;

public class MusicasAPI
{
    private readonly HttpClient _httpClient;

    public MusicasAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<MusicaResponse?> GetMusicaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<MusicaResponse>($"musicas/{nome}");
    }

    public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
    }

    public async Task AddMusicaAsync(MusicaRequest musica)
    {
        await _httpClient.PostAsJsonAsync("musicas", musica);
    }

    public async Task DeleteMusicaAsync(int id)
    {
        await _httpClient.DeleteAsync($"musicas/{id}");
    }

    public async Task UpdateMusicaAsync(MusicaRequestEdit artista)
    {
        await _httpClient.PutAsJsonAsync($"musicas", artista);
    }
}