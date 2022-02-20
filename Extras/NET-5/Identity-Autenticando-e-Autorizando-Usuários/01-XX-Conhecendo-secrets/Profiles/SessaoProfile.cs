using _01_XX_Conhecendo_secrets.Data.Dtos.Sessao;
using _01_XX_Conhecendo_secrets.Models;
using AutoMapper;

namespace _01_XX_Conhecendo_secrets.Profiles
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