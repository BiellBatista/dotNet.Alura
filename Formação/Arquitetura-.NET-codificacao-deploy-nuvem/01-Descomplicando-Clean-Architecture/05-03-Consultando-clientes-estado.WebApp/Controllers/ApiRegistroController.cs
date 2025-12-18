using _05_03_Consultando_clientes_estado.WebApp.Data;
using _05_03_Consultando_clientes_estado.WebApp.Models;
using _05_03_Consultando_clientes_estado.Domain.Models;
using _05_03_Consultando_clientes_estado.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace _05_03_Consultando_clientes_estado.WebApp.Controllers;

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
