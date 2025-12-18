using Refit;

namespace _04_03_Movendo_casos_uso.WebApp.Services;

public interface IViaCepService
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ConsultarAsync(string cep);
}