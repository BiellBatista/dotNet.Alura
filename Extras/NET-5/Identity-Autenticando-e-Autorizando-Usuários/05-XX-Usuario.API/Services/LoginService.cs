using _05_XX_Usuario.API.Data.Requests;
using _05_XX_Usuario.API.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace _05_XX_Usuario.API.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager,
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

                Token token = _tokenService
                                .CreateToken(identityUser, _signInManager
                                                            .UserManager
                                                            .GetRolesAsync(identityUser)
                                                            .Result
                                                            .FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result SolicitaResetUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioProEmail(request.Email);

            if (identityUser is not null)
            {
                string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefini��o");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioProEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager
                                            .UserManager
                                            .ResetPasswordAsync(identityUser, request.Token, request.Password).Result;

            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Houve um erro na opera��o");
        }

        private CustomIdentityUser RecuperaUsuarioProEmail(string email)
        {
            return _signInManager
                                .UserManager
                                .Users
                                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}