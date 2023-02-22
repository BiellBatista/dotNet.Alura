﻿using _04_XX_Filmes.API.Data.Dtos;
using _04_XX_Filmes.API.Models;
using AutoMapper;

namespace _04_XX_Filmes.API.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}