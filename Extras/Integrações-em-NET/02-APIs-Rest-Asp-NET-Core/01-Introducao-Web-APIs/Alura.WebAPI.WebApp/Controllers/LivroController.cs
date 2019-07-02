using System.Linq;
using Alura.ListaLeitura.Persistencia;
using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.WebApp.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly IRepository<Livro> _repo;

        public LivroController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new LivroUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(model.ToLivro());
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ImagemCapa(int id)
        {
            byte[] img = _repo.All
                .Where(l => l.Id == id)
                .Select(l => l.ImagemCapa)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        /**
         * Este método é um Action, mas não retorna uma Action.
         * Qualquer método público definido em um controller é uma action.
         * Neste caso, por padrão, ele irá retornar o objeto em formato JSON.
         * Quando eu acesso este método (action) pelo navegador, o objeto que está no return é serializado para JSON, mas se o id for um inexistente
         * este action retorna NADA (sem código de status, página de erro, dado de erro...) e, por padrão, o navegador não altera a visualização,
         * pois o retorno foi vázio
         */
        public Livro RecuperaLivro(int id)
        {
            return _repo.Find(id);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var model = RecuperaLivro(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model.ToModel());
        }

        [HttpGet]
        public IActionResult DetalhesSemHTML(int id)
        {
            var model = RecuperaLivro(id);
            if (model == null)
            {
                return NotFound();
            }
            return Json(model.ToModel());
        }

        /**
         * Este método retorna qualquer tipo do ActionResult ou um modelo
         */
        public ActionResult<LivroUpload> DetalhesJson(int id)
        {
            var model = RecuperaLivro(id);
            if (model is null)
                return NotFound();
            return model.ToModel(); //retornando o próprio objeto sem converter para JSON. Estilo no método (RecuperaLivro)
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detalhes(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                if (model.Capa == null)
                {
                    livro.ImagemCapa = _repo.All
                        .Where(l => l.Id == livro.Id)
                        .Select(l => l.ImagemCapa)
                        .FirstOrDefault();
                }
                _repo.Alterar(livro);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return RedirectToAction("Index", "Home");
        }
    }
}