using _01_XX_Filmes.API.Data.Dtos;
using _01_XX_Filmes.API.Models;
using AutoMapper;

namespace _01_XX_Filmes.API.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}