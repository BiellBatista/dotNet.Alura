using _05_XX_Executando_Consultas.Data.Dtos.Endereco;
using _05_XX_Executando_Consultas.Models;
using AutoMapper;

namespace _05_XX_Executando_Consultas.Profiles
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