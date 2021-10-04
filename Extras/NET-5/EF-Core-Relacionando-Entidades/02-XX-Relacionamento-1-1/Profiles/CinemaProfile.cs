using _02_XX_Relacionamento_1_1.Data.Dtos.Cinema;
using _02_XX_Relacionamento_1_1.Models;
using AutoMapper;

namespace _02_XX_Relacionamento_1_1.Profiles
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