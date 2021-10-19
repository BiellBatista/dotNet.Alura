using _05_XX_Disparando_Emails.Data.Dtos.Endereco;
using _05_XX_Disparando_Emails.Models;
using AutoMapper;

namespace _05_XX_Disparando_Emails.Profiles
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