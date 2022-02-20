using _02_XX_Usuario.API.Data.Requests;
using _02_XX_Usuario.API.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace _02_XX_Usuario.API.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager,
            TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitaResetUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioProEmail(request.Email);

            if (identityUser is not null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefini��o");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioProEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager
                                            .UserManager
                                            .ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Houve um erro na opera��o");
        }

        private IdentityUser<int> RecuperaUsuarioProEmail(string email)
        {
            return _signInManager
                                .UserManager
                                .Users
                                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}