using _04_XX_Separando_roles.Data.Dtos.Gerente;
using _04_XX_Separando_roles.Models;
using AutoMapper;
using System.Linq;

namespace _04_XX_Separando_roles.Profiles
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