using _04_XX_Item.Service.Dtos;
using _04_XX_Item.Service.Models;
using AutoMapper;

namespace _04_XX_Item.Service.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemCreateDto>();
    }
}