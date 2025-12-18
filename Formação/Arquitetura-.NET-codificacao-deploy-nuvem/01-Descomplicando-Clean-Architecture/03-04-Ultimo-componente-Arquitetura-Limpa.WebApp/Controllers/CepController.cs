using _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Services;

namespace _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Controllers;

public class CepController : Controller
{
    private readonly IViaCepService _cepService;

    public CepController(IViaCepService cepService)
    {
        _cepService = cepService;
    }

    public async Task<IActionResult> Consultar(string cep)
    {
        // consultar o CEP usando Refit
        var response = await _cepService.ConsultarAsync(cep);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            return Json(new { Error = "CEP não encontrado" });
        }

        return Json(new
        {
            CEP = response.Content!.CEP,
            Rua = response.Content.Logradouro,
            Bairro = response.Content.Bairro,
            Municipio = response.Content.Localidade,
            Estado = response.Content.UF
        });
    }
}