using _03_XX_Logando_Usuario.Data.Dtos.Filme;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;

namespace _03_XX_Logando_Usuario.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}