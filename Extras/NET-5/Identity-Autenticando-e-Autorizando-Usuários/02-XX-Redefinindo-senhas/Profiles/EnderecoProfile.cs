using _02_XX_Redefinindo_senhas.Data.Dtos;
using _02_XX_Redefinindo_senhas.Models;
using AutoMapper;

namespace _02_XX_Redefinindo_senhas.Profiles
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