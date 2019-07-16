using System.Linq;
using Alura.ListaLeitura.Persistencia;
using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Alura.WebAPI.WebApp.HttpClients;

namespace Alura.ListaLeitura.WebApp.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly IRepository<Livro> _repo;
        private readonly LivroApiClient _api;

        public LivroController(IRepository<Livro> repository, LivroApiClient api)
        {
            _repo = repository;
            _api = api;
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
        public async Task<IActionResult> ImagemCapa(int id)
        {
            //antigo2 logo abaixo
            //HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new System.Uri("http://localhost:6000/api/");
            //HttpResponseMessage resposta = await httpClient.GetAsync($"livros/{id}/capa"); //enviando um GET
            //resposta.EnsureSuccessStatusCode(); //este método verifica se o status code da API é diferende da família 200. Se for, ele lança um throw

            //byte[] img = await resposta.Content.ReadAsByteArrayAsync();

            //antigo1 logo abaixo
            //byte[] img = _repo.All
            //    .Where(l => l.Id == id)
            //    .Select(l => l.ImagemCapa)
            //    .FirstOrDefault();

            byte[] img = await _api.GetCapaLivroAsync(id);

            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        public Livro RecuperaLivro(int id)
        {
            return _repo.Find(id);
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            //HttpClient httpClient = new HttpClient();
            ////http://localhost:6000/api/livros/{id}
            ////http://localhost:6000/api/listasLeituras/paraLer
            ////http://localhost:6000/api/livros/{id}/capa
            ////como o começo das URI é o mesmo, uso o BaseAddress para facilitar a montagem
            //httpClient.BaseAddress = new System.Uri("http://localhost:6000/api/");
            //HttpResponseMessage resposta = await httpClient.GetAsync($"livros/{id}"); //enviando um GET
            //resposta.EnsureSuccessStatusCode(); //este método verifica se o status code da API é diferende da família 200. Se for, ele lança um throw

            //var model = await resposta.Content.ReadAsAsync<LivroApi>(); //deseralizando o objeto vindo da API

            var model = await _api.GetLivroAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model.ToUpload());
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
