using _03_XX_Logando_Usuario.Data.Dtos.Cinema;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;

namespace _03_XX_Logando_Usuario.Profiles
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