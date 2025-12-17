using _03_03_Criando_funcao_RegistrarCliente.WebApp.Data;
using _03_03_Criando_funcao_RegistrarCliente.WebApp.Models;
using _03_03_Criando_funcao_RegistrarCliente.WebApp.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace _03_03_Criando_funcao_RegistrarCliente.WebApp.Controllers;

[ApiController]
[Route("api/registros")]
public class ApiRegistroController : ControllerBase
{
    private readonly AppDbContext context;

    public ApiRegistroController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(RegistroViewModel request)
    {
        var useCase = new RegistrarCliente(context, request.Nome, new Email(request.Email), request.CPF, request.Celular, request.CEP, request.Rua, request.Numero, request.Complemento, request.Bairro, request.Municipio, request.Estado);

        await useCase.ExecutarAsync();

        return Ok();
    }
}
