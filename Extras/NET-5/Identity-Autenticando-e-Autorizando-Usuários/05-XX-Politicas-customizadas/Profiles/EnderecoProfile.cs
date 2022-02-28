using _05_XX_Politicas_customizadas.Data.Dtos.Endereco;
using _05_XX_Politicas_customizadas.Models;
using AutoMapper;

namespace _05_XX_Politicas_customizadas.Profiles
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