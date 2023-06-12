using _05_XX_Usuarios.API.Data.Dtos;
using _05_XX_Usuarios.API.Models;
using AutoMapper;

namespace _05_XX_Usuarios.API.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}