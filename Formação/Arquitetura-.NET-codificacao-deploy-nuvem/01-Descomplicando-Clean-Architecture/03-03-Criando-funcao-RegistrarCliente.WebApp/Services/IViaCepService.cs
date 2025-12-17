using Refit;

namespace _03_03_Criando_funcao_RegistrarCliente.WebApp.Services;

public interface IViaCepService
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> ConsultarAsync(string cep);
}
