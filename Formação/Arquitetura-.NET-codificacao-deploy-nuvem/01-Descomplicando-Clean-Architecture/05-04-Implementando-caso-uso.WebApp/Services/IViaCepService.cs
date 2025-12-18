using Refit;

namespace _05_04_Implementando_caso_uso.WebApp.Services;

public interface IViaCepService
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ConsultarAsync(string cep);
}
