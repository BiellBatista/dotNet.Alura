using _03_XX_Usuarios.API.Data.Dtos;
using _03_XX_Usuarios.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _03_XX_Usuarios.API.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;

    private readonly SignInManager<Usuario> _signInManager;
    private readonly TokenService _tokenService;
    private readonly UserManager<Usuario> _userManager;

    public UsuarioService(IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task CadastraUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
            throw new ApplicationException("Falha ao cadastrar usuário!");
    }

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
            throw new ApplicationException("Usuário não autenticado!");

        var usuario = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        return _tokenService.GenerateToken(usuario);
    }
}