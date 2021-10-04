using _01_XX_Incrementando_Projeto.Data.Dtos.Cinema;
using _01_XX_Incrementando_Projeto.Models;
using AutoMapper;

namespace _01_XX_Incrementando_Projeto.Profiles
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