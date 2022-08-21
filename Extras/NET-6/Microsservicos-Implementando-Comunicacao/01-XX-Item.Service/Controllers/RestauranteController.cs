using _01_XX_Item.Service.Data;
using _01_XX_Item.Service.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _01_XX_Item.Service.Controllers;

[Route("api/item/[controller]")]
[ApiController]
public class RestauranteController : ControllerBase
{
    private readonly IItemRepository _repository;
    private readonly IMapper _mapper;

    public RestauranteController(IItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RestauranteReadDto>> GetRestaurantes()
    {
        var restaurantes = _repository.GetAllRestaurantes();

        return Ok(_mapper.Map<IEnumerable<RestauranteReadDto>>(restaurantes));
    }

    [HttpPost]
    public ActionResult RecebeRestauranteDoRestauranteService(RestauranteReadDto dto)
    {
        Console.WriteLine(dto.Id);

        return Ok();
    }
}