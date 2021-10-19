using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Endereco;
using _04_XX_Tornando_Cadastro_Sofisticado.Models;
using AutoMapper;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Profiles
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