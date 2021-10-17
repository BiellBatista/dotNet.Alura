using _05_XX_Executando_Consultas.Data.Dtos.Filme;
using _05_XX_Executando_Consultas.Models;
using AutoMapper;

namespace _05_XX_Executando_Consultas.Profiles
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