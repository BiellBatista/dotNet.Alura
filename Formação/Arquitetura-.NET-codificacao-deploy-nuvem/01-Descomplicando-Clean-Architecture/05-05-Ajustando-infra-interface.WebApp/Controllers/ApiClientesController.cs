using _05_05_Ajustando_infra_interface.Application.UseCases;
using _05_05_Ajustando_infra_interface.Domain.Models;
using _05_05_Ajustando_infra_interface.WebApp.Data;
using _05_05_Ajustando_infra_interface.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace _05_05_Ajustando_infra_interface.WebApp.Controllers;

[ApiController]
[Route("api/clientes")]
public class ApiClientesController : ControllerBase
{
    private readonly AppDbContext context;

    public ApiClientesController(AppDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(string? estado)
    {
        var useCase = new ConsultarClientes(UfStringConverter.From(estado), context);

        var clientes = await useCase.ExecutarAsync();

        return Ok(clientes.Select(c => new ClienteResponse(c.Id.ToString(), c.Nome, c.Email.Value)));
    }
}