using _05_XX_Disparando_Emails.Data.Dtos.Cinema;
using _05_XX_Disparando_Emails.Models;
using AutoMapper;

namespace _05_XX_Disparando_Emails.Profiles
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