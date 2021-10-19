using _03_XX_Logando_Usuario.Data.Dtos.Endereco;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;

namespace _03_XX_Logando_Usuario.Profiles
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