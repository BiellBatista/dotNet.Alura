using _04_XX_Restaurante.Service.Dtos;
using _04_XX_Restaurante.Service.Models;
using AutoMapper;

namespace _04_XX_Restaurante.Service.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<RestauranteCreateDto, Restaurante>();
    }
}