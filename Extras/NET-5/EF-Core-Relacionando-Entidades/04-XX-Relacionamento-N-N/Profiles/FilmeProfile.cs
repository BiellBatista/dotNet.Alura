using _04_XX_Relacionamento_N_N.Data.Dtos.Filme;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;

namespace _04_XX_Relacionamento_N_N.Profiles
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