﻿using _03_XX_Implementando_roles.Data.Dtos.Gerente;
using _03_XX_Implementando_roles.Models;
using AutoMapper;
using System.Linq;

namespace _03_XX_Implementando_roles.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));
        }
    }
}