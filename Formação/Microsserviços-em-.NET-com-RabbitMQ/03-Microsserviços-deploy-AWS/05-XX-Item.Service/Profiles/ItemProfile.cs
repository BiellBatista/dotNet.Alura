using _05_XX_Item.Service.Dtos;
using _05_XX_Item.Service.Models;
using AutoMapper;

namespace _05_XX_Item.Service.Profiles;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<RestauranteReadDto, Restaurante>().ForMember(dest => dest.IdExterno, opt => opt.MapFrom(src => src.Id));
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<ItemCreateDto, Item>();
        CreateMap<Item, ItemCreateDto>();
    }
}