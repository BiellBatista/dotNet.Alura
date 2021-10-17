using _04_XX_Relacionamento_N_N.Data.Dtos.Cinema;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;

namespace _04_XX_Relacionamento_N_N.Profiles
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