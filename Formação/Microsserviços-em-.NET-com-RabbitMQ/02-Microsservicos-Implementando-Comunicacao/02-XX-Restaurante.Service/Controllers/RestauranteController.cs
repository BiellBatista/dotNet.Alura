using _02_XX_Restaurante.Service.Data;
using _02_XX_Restaurante.Service.Dtos;
using _02_XX_Restaurante.Service.ItemServiceHttpClient;
using _02_XX_Restaurante.Service.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Restaurante.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly IRestauranteRepository _repository;
    private readonly IMapper _mapper;
    private IItemServiceHttpClient _itemServiceHttpClient;

    public RestauranteController(
        IRestauranteRepository repository,
        IMapper mapper,
        IItemServiceHttpClient itemServiceHttpClient)
    {
        _repository = repository;
        _mapper = mapper;
        _itemServiceHttpClient = itemServiceHttpClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RestauranteReadDto>> GetAllRestaurantes()
    {
        var restaurantes = _repository.GetAllRestaurantes();

        return Ok(_mapper.Map<IEnumerable<RestauranteReadDto>>(restaurantes));
    }

    [HttpGet("{id}", Name = "GetRestauranteById")]
    public ActionResult<RestauranteReadDto> GetRestauranteById(int id)
    {
        var restaurante = _repository.GetRestauranteById(id);
        if (restaurante != null)
        {
            return Ok(_mapper.Map<RestauranteReadDto>(restaurante));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<RestauranteReadDto>> CreateRestaurante(RestauranteCreateDto restauranteCreateDto)
    {
        var restaurante = _mapper.Map<Restaurante>(restauranteCreateDto);
        _repository.CreateRestaurante(restaurante);
        _repository.SaveChanges();

        var restauranteReadDto = _mapper.Map<RestauranteReadDto>(restaurante);

        _itemServiceHttpClient.EnviaRestauranteParaItemService(restauranteReadDto);

        return CreatedAtRoute(nameof(GetRestauranteById), new { restauranteReadDto.Id }, restauranteReadDto);
    }
}