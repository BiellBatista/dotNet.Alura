using _01_XX_Usuarios.API.Data.Dtos;
using _01_XX_Usuarios.API.Models;
using AutoMapper;

namespace _01_XX_Usuarios.API.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}