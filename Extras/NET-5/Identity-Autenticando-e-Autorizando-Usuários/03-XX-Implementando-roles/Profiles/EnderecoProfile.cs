using _03_XX_Implementando_roles.Data.Dtos.Endereco;
using _03_XX_Implementando_roles.Models;
using AutoMapper;

namespace _03_XX_Implementando_roles.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}