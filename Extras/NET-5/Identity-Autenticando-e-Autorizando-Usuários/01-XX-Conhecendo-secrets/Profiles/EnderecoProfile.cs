using _01_XX_Conhecendo_secrets.Data.Dtos;
using _01_XX_Conhecendo_secrets.Models;
using AutoMapper;

namespace _01_XX_Conhecendo_secrets.Profiles
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