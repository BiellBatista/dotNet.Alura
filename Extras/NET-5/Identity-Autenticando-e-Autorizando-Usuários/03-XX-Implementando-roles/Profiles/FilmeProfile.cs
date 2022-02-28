using _03_XX_Implementando_roles.Data.Dtos.Filme;
using _03_XX_Implementando_roles.Models;
using AutoMapper;

namespace _03_XX_Implementando_roles.Profiles
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