using ASP_NET_Identity_Parte_4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace ASP_NET_Identity_Parte_4.ViewModels
{
    public class UsuarioEditarFuncoesViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public List<UsuarioFuncaoViewModel> Funcoes { get; set; }

        public UsuarioEditarFuncoesViewModel()
        {
        }

        public UsuarioEditarFuncoesViewModel(UserAplication usuario, RoleManager<IdentityRole> roleManager)
        {
            Id = usuario.Id;
            FullName = usuario.FullName;
            Email = usuario.Email;
            UserName = usuario.UserName;

            Funcoes =
                roleManager
                .Roles
                .ToList()
                .Select(funcao =>
                    new UsuarioFuncaoViewModel {
                        Nome = funcao.Name,
                        Id = funcao.Id
                        })
                    .ToList();

            foreach(var funcao in Funcoes)
            {
                var funcaoUsuario = usuario.Roles.Any(
                        usuarioRole => usuarioRole.RoleId == funcao.Id
                    );

                funcao.Selecionado = funcaoUsuario;
            }
        }
    }
}