using _03_XX_Relacionamento_1_N.Data.Dtos.Cinema;
using _03_XX_Relacionamento_1_N.Models;
using AutoMapper;

namespace _03_XX_Relacionamento_1_N.Profiles
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