using _04_XX_Separando_roles.Data.Dtos.Cinema;
using _04_XX_Separando_roles.Models;
using AutoMapper;

namespace _04_XX_Separando_roles.Profiles
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