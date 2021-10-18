using _01_XX_Arrumando_Codigo.Data.Dtos.Sessao;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;

namespace _01_XX_Arrumando_Codigo.Profiles
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