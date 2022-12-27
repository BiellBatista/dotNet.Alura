using _03_XX_Item.Service.Dtos;
using _03_XX_Item.Service.Models;
using AutoMapper;

namespace _03_XX_Item.Service.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemCreateDto>();
    }
}