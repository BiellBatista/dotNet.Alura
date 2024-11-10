using _01_XX_Conhecendo_Excecoes.Dtos;
using _01_XX_Conhecendo_Excecoes.Services;
using Microsoft.AspNetCore.Mvc;

namespace _01_XX_Conhecendo_Excecoes.Controllers;

[ApiController]
[Route("[controller]")]
public class AdocaoController : ControllerBase
{
    private readonly AdocaoService _acaoService;

    public AdocaoController(AdocaoService acaoService)
    {
        _acaoService = acaoService;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        List<AdocaoDto> adocoes = _acaoService.ListarTodos();
        return Ok(adocoes);
    }

    [HttpGet("{id}")]
    public IActionResult Buscar(long id)
    {
        AdocaoDto? adocao = _acaoService.Listar(id);
        return Ok(adocao);
    }

    [HttpPost]
    public IActionResult Solicitar([FromBody] SolicitacaoDeAdocaoDto dados)
    {
        _acaoService.Solicitar(dados);
        return Ok("Adoção solicitada com sucesso!");
    }

    [HttpPut("aprovar")]
    public IActionResult Aprovar([FromBody] AprovarAdocaoDto dto)
    {
        _acaoService.Aprovar(dto);
        return Ok();
    }

    [HttpPut("reprovar")]
    public IActionResult Reprovar([FromBody] ReprovarAdocaoDto dto)
    {
        _acaoService.Reprovar(dto);
        return Ok();
    }
}