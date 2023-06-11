using _02_XX_Usuarios.API.Data.Dtos;
using _02_XX_Usuarios.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _02_XX_Usuarios.API.Services;

public class CadastroService
{
    private readonly IMapper _mapper;

    private readonly UserManager<Usuario> _userManager;

    public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task CadastraUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
            throw new ApplicationException("Falha ao cadastrar usuário!");
    }
}