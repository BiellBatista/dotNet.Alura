using _02_XX_Conhecendo_Identity.Data.Dtos.Filme;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;

namespace _02_XX_Conhecendo_Identity.Profiles
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