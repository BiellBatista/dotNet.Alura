using _02_XX_Item.Service.Dtos;
using _02_XX_Item.Service.Models;
using AutoMapper;

namespace _02_XX_Item.Service.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemCreateDto>();
    }
}