using _02_XX_Conhecendo_Identity.Data.Dtos.Endereco;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;

namespace _02_XX_Conhecendo_Identity.Profiles
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