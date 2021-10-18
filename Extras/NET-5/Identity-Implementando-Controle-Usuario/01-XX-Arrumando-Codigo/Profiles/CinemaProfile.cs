using _01_XX_Arrumando_Codigo.Data.Dtos.Cinema;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;

namespace _01_XX_Arrumando_Codigo.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}