using _03_XX_Filmes.API.Data.Dtos;
using _03_XX_Filmes.API.Models;
using AutoMapper;

namespace _03_XX_Filmes.API.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();

        CreateMap<UpdateFilmeDto, Filme>();

        CreateMap<Filme, UpdateFilmeDto>();

        CreateMap<Filme, ReadFilmeDto>()
           .ForMember(filmeDto => filmeDto.Sessoes,
                   opt => opt.MapFrom(filme => filme.Sessoes));
    }
}