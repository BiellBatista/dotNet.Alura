using Refit;

namespace _03_02_Nova_forma_registrar_clientes.WebApp.Services;

public interface IViaCepService
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ConsultarAsync(string cep);
}
