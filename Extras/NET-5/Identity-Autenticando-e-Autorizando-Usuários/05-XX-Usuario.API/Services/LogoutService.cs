using _05_XX_Usuario.API.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace _05_XX_Usuario.API.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            Task resultadoIdentity = _signInManager.SignOutAsync();

            if (resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            return Result.Fail("Logout falhou");
        }
    }
}