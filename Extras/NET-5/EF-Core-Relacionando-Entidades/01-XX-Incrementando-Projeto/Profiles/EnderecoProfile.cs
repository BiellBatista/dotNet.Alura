using _01_XX_Incrementando_Projeto.Data.Dtos.Endereco;
using _01_XX_Incrementando_Projeto.Models;
using AutoMapper;

namespace _01_XX_Incrementando_Projeto.Profiles
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