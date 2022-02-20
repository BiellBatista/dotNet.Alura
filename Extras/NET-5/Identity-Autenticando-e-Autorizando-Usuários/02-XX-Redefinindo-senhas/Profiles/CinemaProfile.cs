using _02_XX_Redefinindo_senhas.Data.Dtos;
using _02_XX_Redefinindo_senhas.Models;
using AutoMapper;

namespace _02_XX_Redefinindo_senhas.Profiles
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