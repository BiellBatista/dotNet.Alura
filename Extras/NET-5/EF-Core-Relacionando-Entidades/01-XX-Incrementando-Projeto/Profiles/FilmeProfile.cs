using _01_XX_Incrementando_Projeto.Data.Dtos;
using _01_XX_Incrementando_Projeto.Models;
using AutoMapper;

namespace _01_XX_Incrementando_Projeto.Profiles
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