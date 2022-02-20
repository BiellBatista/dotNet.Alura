using _02_XX_Redefinindo_senhas.Data.Dtos.Gerente;
using _02_XX_Redefinindo_senhas.Models;
using AutoMapper;
using System.Linq;

namespace _02_XX_Redefinindo_senhas.Profiles
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