using _05_XX_Boas_Praticas.Dtos;
using _05_XX_Boas_Praticas.Services;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Boas_Praticas.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly PetService _petService;

    public PetController(PetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        List<PetDto> pets = _petService.ListarTodos();
        return Ok(pets);
    }

    [HttpPost]
    public IActionResult Cadastrar([FromForm] CadastroPetDto dados)
    {
        _petService.Cadastrar(dados);
        return Ok();
    }
}