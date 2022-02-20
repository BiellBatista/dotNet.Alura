using _01_XX_Conhecendo_secrets.Data.Dtos;
using _01_XX_Conhecendo_secrets.Models;
using AutoMapper;

namespace _01_XX_Conhecendo_secrets.Profiles
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