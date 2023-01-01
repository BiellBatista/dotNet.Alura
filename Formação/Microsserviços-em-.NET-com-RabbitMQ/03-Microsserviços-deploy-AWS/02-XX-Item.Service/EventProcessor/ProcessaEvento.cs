using _02_XX_Item.Service.Data;
using _02_XX_Item.Service.Dtos;
using _02_XX_Item.Service.Models;
using AutoMapper;
using System.Text.Json;

namespace _02_XX_Item.Service.EventProcessor;

public class ProcessaEvento : IProcessaEvento
{
    private readonly IMapper _mapper;
    private readonly IServiceScopeFactory _scopeFactory;

    public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory)
    {
        _mapper = mapper;
        _scopeFactory = scopeFactory;
    }

    public void Processa(string mensagem)
    {
        using var scope = _scopeFactory.CreateScope();

        var itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();
        var restauranteReadDto = JsonSerializer.Deserialize<RestauranteReadDto>(mensagem);
        var restaurante = _mapper.Map<Restaurante>(restauranteReadDto);

        if (!itemRepository.ExisteRestauranteExterno(restaurante.Id))
        {
            itemRepository.CreateRestaurante(restaurante);
            itemRepository.SaveChanges();
        }
    }
}