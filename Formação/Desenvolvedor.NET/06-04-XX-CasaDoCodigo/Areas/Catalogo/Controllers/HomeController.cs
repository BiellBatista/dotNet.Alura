using System.Threading.Tasks;
using _06_04_XX_CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalago.Controllers
{
    [Area("Catalogo")]
    public class HomeController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index(string pesquisa)
        {
            return View(await produtoRepository.GetProdutosAsync(pesquisa));
        }
    }
}