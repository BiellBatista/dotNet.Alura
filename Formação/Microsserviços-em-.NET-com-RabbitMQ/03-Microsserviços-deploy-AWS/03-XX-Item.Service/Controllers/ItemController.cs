using _02_XX_Item.Service.Data;
using _02_XX_Item.Service.Dtos;
using _02_XX_Item.Service.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Item.Service.Controllers;

[Route("api/item/restaurante/{restauranteId}/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _repository;
    private readonly IMapper _mapper;

    public ItemController(IItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ItemReadDto>> GetItensForRestaurante(int restauranteId)
    {
        if (!_repository.RestauranteExiste(restauranteId)) return NotFound();

        var itens = _repository.GetItensDeRestaurante(restauranteId);

        return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(itens));
    }

    [HttpGet("{ItemId}", Name = "GetItemForRestaurante")]
    public ActionResult<ItemReadDto> GetItemForRestaurante(int restauranteId, int itemId)
    {
        if (!_repository.RestauranteExiste(restauranteId)) return NotFound();

        var item = _repository.GetItem(restauranteId, itemId);

        if (item is null) return NotFound();

        return Ok(_mapper.Map<ItemReadDto>(item));
    }

    [HttpPost]
    public ActionResult<ItemReadDto> CreateItemForRestaurante(int restauranteId, ItemCreateDto itemDto)
    {
        if (!_repository.RestauranteExiste(restauranteId)) return NotFound();

        var item = _mapper.Map<Item>(itemDto);

        _repository.CreateItem(restauranteId, item);
        _repository.SaveChanges();

        var itemReadDto = _mapper.Map<ItemReadDto>(item);

        return CreatedAtRoute(nameof(GetItemForRestaurante),
            new { restauranteId, ItemId = itemReadDto.Id }, itemReadDto);
    }
}