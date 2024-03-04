using _03_02_XX_CRUD_Artista.Web.Response;

namespace _03_02_XX_CRUD_Artista.Web.Services;

public class MusicasAPI
{
    private readonly HttpClient _httpClient;

    public MusicasAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
    }
}