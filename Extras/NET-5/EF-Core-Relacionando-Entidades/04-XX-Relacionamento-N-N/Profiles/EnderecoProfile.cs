using _04_XX_Relacionamento_N_N.Data.Dtos.Endereco;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;

namespace _04_XX_Relacionamento_N_N.Profiles
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