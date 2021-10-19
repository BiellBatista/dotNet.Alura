using _05_XX_Usuario.API.Data.Dtos;
using _05_XX_Usuario.API.Data.Requests;
using _05_XX_Usuario.API.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _05_XX_Usuario.API.Services
{
    public class CadastroService
    {
        private IMapper _mapper;

        private EmailService _emailService;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, EmailService emailService, UserManager<IdentityUser<int>> userManager)
        {
            _emailService = emailService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);

            if (resultadoIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(code).WithSuccess(code);
            }

            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.Where(u => u.Id == request.UsuarioId).FirstOrDefault();
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao);

            if (identityResult.Result.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}