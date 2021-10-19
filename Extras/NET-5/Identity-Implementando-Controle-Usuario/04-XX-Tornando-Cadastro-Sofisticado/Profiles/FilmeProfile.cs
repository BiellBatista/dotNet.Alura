using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Filme;
using _04_XX_Tornando_Cadastro_Sofisticado.Models;
using AutoMapper;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Profiles
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