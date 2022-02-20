using _02_XX_Redefinindo_senhas.Data.Dtos;
using _02_XX_Redefinindo_senhas.Models;
using AutoMapper;

namespace _02_XX_Redefinindo_senhas.Profiles
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