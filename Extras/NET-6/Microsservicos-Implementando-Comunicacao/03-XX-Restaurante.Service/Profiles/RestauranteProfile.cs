using _03_XX_Restaurante.Service.Dtos;
using _03_XX_Restaurante.Service.Models;
using AutoMapper;

namespace _03_XX_Restaurante.Service.Profiles;

public class RestauranteProfile : Profile
{
    public RestauranteProfile()
    {
        CreateMap<Restaurante, RestauranteReadDto>();
        CreateMap<RestauranteCreateDto, Restaurante>();
    }
}