using _01_XX_Restaurante.Service.Dtos;
using _01_XX_Restaurante.Service.Models;
using AutoMapper;

namespace _01_XX_Restaurante.Service.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<RestauranteCreateDto, Restaurante>();
    }
}