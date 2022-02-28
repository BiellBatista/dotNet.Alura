using _05_XX_Usuario.API.Data.Dtos.Usuario;
using _05_XX_Usuario.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _05_XX_Usuario.API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}