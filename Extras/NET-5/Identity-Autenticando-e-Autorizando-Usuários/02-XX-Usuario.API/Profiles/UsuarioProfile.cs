using _02_XX_Usuario.API.Data.Dtos.Usuario;
using _02_XX_Usuario.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _02_XX_Usuario.API.Profiles
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