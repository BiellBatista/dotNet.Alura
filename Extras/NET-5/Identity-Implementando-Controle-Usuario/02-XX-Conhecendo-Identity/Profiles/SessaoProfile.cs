using _02_XX_Conhecendo_Identity.Data.Dtos.Sessao;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;

namespace _02_XX_Conhecendo_Identity.Profiles
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