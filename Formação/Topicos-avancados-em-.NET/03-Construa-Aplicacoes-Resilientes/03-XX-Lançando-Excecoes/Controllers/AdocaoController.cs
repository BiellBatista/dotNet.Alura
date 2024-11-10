using _03_XX_Lançando_Excecoes.Dtos;
using _03_XX_Lançando_Excecoes.Exceptions;
using _03_XX_Lançando_Excecoes.Services;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Lançando_Excecoes.Controllers;

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
        try
        {
            _acaoService.Solicitar(dados);
            return Ok("Adoção solicitada com sucesso!");
        }
        catch (NullReferenceException ex)
        {
            return NotFound("Falha ao encontrar objeto solicitado!");
        }
        catch (Exception ex) when (ex is PetAdotadoException
            || ex is PetEmProcessoDeAdocaoException
            || ex is TutorComLimiteAtingidoException)
        {
            return BadRequest("Houve uma falha no processo de adoção!");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Falha interna na aplicação!");
        }
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