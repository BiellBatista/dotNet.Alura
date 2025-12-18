using _04_02_Separando_dominio.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace _04_02_Separando_dominio.WebApp.Controllers;

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
            response.Content!.CEP,
            Rua = response.Content.Logradouro,
            response.Content.Bairro,
            Municipio = response.Content.Localidade,
            Estado = response.Content.UF
        });
    }
}