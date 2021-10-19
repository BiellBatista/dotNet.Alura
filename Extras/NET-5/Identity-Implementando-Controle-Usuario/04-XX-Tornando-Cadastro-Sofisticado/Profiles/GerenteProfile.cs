using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Gerente;
using _04_XX_Tornando_Cadastro_Sofisticado.Models;
using AutoMapper;
using System.Linq;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                    .ForMember(gerente => gerente.Cinemas, opts => opts
                            //para que seja possível fazer isso, o atributo cinemas deve ser um object
                            .MapFrom(gerente => gerente.Cinemas.Select(
                                c => new
                                {
                                    c.Id,
                                    c.Nome,
                                    c.Endereco,
                                    c.EnderecoId
                                })));
        }
    }
}