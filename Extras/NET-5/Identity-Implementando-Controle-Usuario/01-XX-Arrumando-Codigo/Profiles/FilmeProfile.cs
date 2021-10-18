using _01_XX_Arrumando_Codigo.Data.Dtos.Filme;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;

namespace _01_XX_Arrumando_Codigo.Profiles
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