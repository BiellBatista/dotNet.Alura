using _02_XX_Usuarios.API.Data.Dtos;
using _02_XX_Usuarios.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly CadastroService _cadastroService;

    public UsuarioController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.CadastraUsuario(dto);

        return Ok("Usuário cadastrado!");
    }
}