using _05_XX_Filmes.API.Data.Dtos;
using _05_XX_Filmes.API.Models;
using AutoMapper;

namespace _05_XX_Filmes.API.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}