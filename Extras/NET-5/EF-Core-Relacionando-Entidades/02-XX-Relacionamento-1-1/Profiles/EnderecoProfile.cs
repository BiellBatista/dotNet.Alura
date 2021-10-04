using _02_XX_Relacionamento_1_1.Data.Dtos.Endereco;
using _02_XX_Relacionamento_1_1.Models;
using AutoMapper;

namespace _02_XX_Relacionamento_1_1.Profiles
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