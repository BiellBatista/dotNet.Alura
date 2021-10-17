using _05_XX_Executando_Consultas.Data.Dtos.Cinema;
using _05_XX_Executando_Consultas.Models;
using AutoMapper;

namespace _05_XX_Executando_Consultas.Profiles
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