using _01_XX_Conhecendo_secrets.Data.Dtos.Gerente;
using _01_XX_Conhecendo_secrets.Models;
using AutoMapper;
using System.Linq;

namespace _01_XX_Conhecendo_secrets.Profiles
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