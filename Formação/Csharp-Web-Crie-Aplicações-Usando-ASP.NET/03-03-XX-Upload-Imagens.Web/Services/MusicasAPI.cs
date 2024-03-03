using _03_03_XX_Upload_Imagens.Web.Response;

namespace _03_03_XX_Upload_Imagens.Web.Services;

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