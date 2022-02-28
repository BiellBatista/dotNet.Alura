using _04_XX_Separando_roles.Data.Dtos.Endereco;
using _04_XX_Separando_roles.Models;
using AutoMapper;

namespace _04_XX_Separando_roles.Profiles
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