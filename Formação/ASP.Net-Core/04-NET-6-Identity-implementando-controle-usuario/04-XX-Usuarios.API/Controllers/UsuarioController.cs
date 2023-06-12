using _04_XX_Usuarios.API.Data.Dtos;
using _04_XX_Usuarios.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _04_XX_Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.CadastraUsuario(dto);

        return Ok("Usuário cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);

        return Ok(token);
    }
}