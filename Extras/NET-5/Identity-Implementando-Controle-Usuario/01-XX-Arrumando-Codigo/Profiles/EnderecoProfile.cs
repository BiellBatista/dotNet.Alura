using _01_XX_Arrumando_Codigo.Data.Dtos.Endereco;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;

namespace _01_XX_Arrumando_Codigo.Profiles
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