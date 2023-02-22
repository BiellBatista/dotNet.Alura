using _02_XX_Filmes.API.Data.Dtos;
using _02_XX_Filmes.API.Models;
using AutoMapper;

namespace _02_XX_Filmes.API.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}