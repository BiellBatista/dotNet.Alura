using _05_XX_Politicas_customizadas.Data.Dtos.Filme;
using _05_XX_Politicas_customizadas.Models;
using AutoMapper;

namespace _05_XX_Politicas_customizadas.Profiles
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