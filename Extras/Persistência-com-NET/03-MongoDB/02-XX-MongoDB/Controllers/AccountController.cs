using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _02_XX_MongoDB.Models;
using _02_XX_MongoDB.Models.Account;

namespace _02_XX_MongoDB.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Acessar(string returnUrl)
        {
            var model = new AcessarModel
            {
                RetornoUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Acessar(AcessarModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // XXXX TRABALHE AQUI
            // Neste ponto iremos buscar o email digitado ao acessar o Blog
            // Descomentar as linhas abaixo

            //if (user == null)
            //{
            //    ModelState.AddModelError("Email", "Correio não foi registrado.");
            //    return View(model);
            //}

            //var identity = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Nome),
            //        new Claim(ClaimTypes.Email, user.Email)
            //    },
            //    "ApplicationCookie");

            //var context = Request.GetOwinContext();
            //var authManager = context.Authentication;

            //authManager.SignIn(identity);

            return Redirect(GetRedirectUrl(model.RetornoUrl));
        }

        [HttpPost]
        public ActionResult Desconectar()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View(new RegistrarModel());
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(RegistrarModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email
            };

            var conexaoMongoDB = new AcessoMongoDB();

            await conexaoMongoDB.Usuarios.InsertOneAsync(user);

            return RedirectToAction("Index", "Home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}