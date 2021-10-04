using _03_XX_Relacionamento_1_N.Data.Dtos.Filme;
using _03_XX_Relacionamento_1_N.Models;
using AutoMapper;

namespace _03_XX_Relacionamento_1_N.Profiles
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