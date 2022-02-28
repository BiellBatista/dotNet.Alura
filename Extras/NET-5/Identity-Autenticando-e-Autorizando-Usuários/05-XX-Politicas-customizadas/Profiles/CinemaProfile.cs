using _05_XX_Politicas_customizadas.Data.Dtos.Cinema;
using _05_XX_Politicas_customizadas.Models;
using AutoMapper;

namespace _05_XX_Politicas_customizadas.Profiles
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