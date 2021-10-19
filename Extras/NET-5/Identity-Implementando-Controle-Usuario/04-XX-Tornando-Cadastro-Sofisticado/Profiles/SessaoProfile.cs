using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Sessao;
using _04_XX_Tornando_Cadastro_Sofisticado.Models;
using AutoMapper;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                    .ForMember(dto => dto.HorarioDeInicio, opts => opts
                        .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}