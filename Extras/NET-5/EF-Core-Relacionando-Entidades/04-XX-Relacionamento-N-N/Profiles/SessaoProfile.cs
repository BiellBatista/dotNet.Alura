using _04_XX_Relacionamento_N_N.Data.Dtos.Sessao;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;

namespace _04_XX_Relacionamento_N_N.Profiles
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