using _03_XX_Relacionamento_1_N.Data.Dtos.Endereco;
using _03_XX_Relacionamento_1_N.Models;
using AutoMapper;

namespace _03_XX_Relacionamento_1_N.Profiles
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