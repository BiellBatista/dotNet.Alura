using _02_XX_Redefinindo_senhas.Data.Dtos.Sessao;
using _02_XX_Redefinindo_senhas.Models;
using AutoMapper;

namespace _02_XX_Redefinindo_senhas.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}