using _03_XX_Relacionamento_1_N.Data.Dtos.Gerente;
using _03_XX_Relacionamento_1_N.Models;
using AutoMapper;

namespace _03_XX_Relacionamento_1_N.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
        }
    }
}