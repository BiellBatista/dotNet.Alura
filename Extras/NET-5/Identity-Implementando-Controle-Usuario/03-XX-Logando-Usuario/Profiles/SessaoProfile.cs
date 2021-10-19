using _03_XX_Logando_Usuario.Data.Dtos.Sessao;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;

namespace _03_XX_Logando_Usuario.Profiles
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