using _02_XX_Relacionamento_1_1.Data.Dtos.Filme;
using _02_XX_Relacionamento_1_1.Models;
using AutoMapper;

namespace _02_XX_Relacionamento_1_1.Profiles
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