using Refit;

namespace _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Services;

public interface IViaCepService
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ConsultarAsync(string cep);
}
