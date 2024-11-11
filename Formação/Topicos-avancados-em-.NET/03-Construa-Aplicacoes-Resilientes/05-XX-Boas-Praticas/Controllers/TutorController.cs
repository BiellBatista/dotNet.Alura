using _05_XX_Boas_Praticas.Dtos;
using _05_XX_Boas_Praticas.Services;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Boas_Praticas.Controllers;

[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{
    private readonly TutorService _service;

    public TutorController(TutorService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        List<TutorDto> tutores = _service.ListarTodos();
        return Ok(tutores);
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody] CadastroTutorDto dados)
    {
        _service.Cadastrar(dados);
        return Ok();
    }
}