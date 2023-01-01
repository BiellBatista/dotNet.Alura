using _05_XX_Restaurante.Service.Dtos;
using _05_XX_Restaurante.Service.Models;
using AutoMapper;

namespace _05_XX_Restaurante.Service.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<RestauranteCreateDto, Restaurante>();
    }
}