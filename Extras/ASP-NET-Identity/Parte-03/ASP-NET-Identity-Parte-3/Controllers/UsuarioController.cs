using ASP_NET_Identity_Parte_3.Models;
using ASP_NET_Identity_Parte_3.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_3.Controllers
{
    [Authorize(Roles = RolesName.ADMINISTRADOR)]
    public class UsuarioController : Controller
    {
        private UserManager<UserAplication> _userManager;
        public UserManager<UserAplication> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<UserAplication>>();
                }

                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }

        private RoleManager<IdentityRole> _roleManager;
        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                if (_roleManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _roleManager = contextOwin.GetUserManager<RoleManager<IdentityRole>>();
                }

                return _roleManager;
            }
            set
            {
                _roleManager = value;
            }
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios =
                UserManager
                .Users
                .ToList()
                .Select(usuario => new UsuarioViewModel(usuario));

            return View(usuarios);
        }

        public async Task<ActionResult> EditarFuncoes(string id)
        {
            var usuario = await UserManager.FindByIdAsync(id);
            var modelo = new UsuarioEditarFuncoesViewModel(usuario, RoleManager);

            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> EditarFuncoes(UsuarioEditarFuncoesViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                var usuario = await UserManager.FindByIdAsync(modelo.Id);
                var rolesUsuario = UserManager.GetRoles(usuario.Id);
                var resultadoRemoca = await UserManager.RemoveFromRolesAsync(
                    usuario.Id,
                    rolesUsuario.ToArray()
                    );

                if(resultadoRemoca.Succeeded)
                {
                    var funcaosSelecionadasPeloAdm = modelo
                        .Funcoes
                        .Where(funcao => funcao.Selecionado)
                        .Select(funcao => funcao.Nome)
                        .ToArray();

                    var resultadoAdicao = await UserManager.AddToRolesAsync(
                        usuario.Id,
                        funcaosSelecionadasPeloAdm);

                    if (resultadoAdicao.Succeeded)
                        return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}