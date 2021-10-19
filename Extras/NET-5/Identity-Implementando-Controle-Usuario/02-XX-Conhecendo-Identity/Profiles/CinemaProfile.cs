using _02_XX_Conhecendo_Identity.Data.Dtos.Cinema;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;

namespace _02_XX_Conhecendo_Identity.Profiles
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