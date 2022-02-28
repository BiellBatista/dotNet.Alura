using _04_XX_Separando_roles.Data.Dtos.Sessao;
using _04_XX_Separando_roles.Models;
using AutoMapper;

namespace _04_XX_Separando_roles.Profiles
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