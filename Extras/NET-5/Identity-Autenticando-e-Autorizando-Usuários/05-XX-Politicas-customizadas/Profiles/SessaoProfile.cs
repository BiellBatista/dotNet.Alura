using _05_XX_Politicas_customizadas.Data.Dtos.Sessao;
using _05_XX_Politicas_customizadas.Models;
using AutoMapper;

namespace _05_XX_Politicas_customizadas.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * -1)));
        }
    }
}