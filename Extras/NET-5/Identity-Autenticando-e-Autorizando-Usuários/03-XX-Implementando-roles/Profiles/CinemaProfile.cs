using _03_XX_Implementando_roles.Data.Dtos.Cinema;
using _03_XX_Implementando_roles.Models;
using AutoMapper;

namespace _03_XX_Implementando_roles.Profiles
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