using _01_XX_Conhecendo_secrets.Data.Dtos;
using _01_XX_Conhecendo_secrets.Models;
using AutoMapper;

namespace _01_XX_Conhecendo_secrets.Profiles
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