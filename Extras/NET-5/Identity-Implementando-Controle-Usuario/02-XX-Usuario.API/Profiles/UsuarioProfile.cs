using _02_XX_Usuario.API.Data.Dtos;
using _02_XX_Usuario.API.Models;
using AutoMapper;

namespace _02_XX_Usuario.API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}