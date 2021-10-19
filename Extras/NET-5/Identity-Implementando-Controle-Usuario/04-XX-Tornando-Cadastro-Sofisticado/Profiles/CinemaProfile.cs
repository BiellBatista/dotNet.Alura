using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Cinema;
using _04_XX_Tornando_Cadastro_Sofisticado.Models;
using AutoMapper;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Profiles
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