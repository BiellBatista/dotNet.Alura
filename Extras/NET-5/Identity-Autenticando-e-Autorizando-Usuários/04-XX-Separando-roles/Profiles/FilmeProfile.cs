using _04_XX_Separando_roles.Data.Dtos.Filme;
using _04_XX_Separando_roles.Models;
using AutoMapper;

namespace _04_XX_Separando_roles.Profiles
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