using _05_XX_Melhorando_codigo.Data.Dtos;
using _05_XX_Melhorando_codigo.Models;
using AutoMapper;

namespace _05_XX_Melhorando_codigo.Profiles
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