using _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Data;
using _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Models;
using _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.UseCases;

namespace _03_04_Ultimo_componente_Arquitetura_Limpa.WebApp.Controllers;

public class RegistroController : Controller
{
    private readonly AppDbContext context;

    public RegistroController(AppDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Sucesso() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(RegistroViewModel form)
    {
        if (!ModelState.IsValid) return View("Index", form);

        var useCase = new RegistrarCliente(context, form.Nome, new Email(form.Email), form.CPF, form.Celular, form.CEP, form.Rua, form.Numero, form.Complemento, form.Bairro, form.Municipio, form.Estado);

        await useCase.ExecutarAsync();

        return RedirectToAction("Sucesso");
    }
}