using _04_06_Interacoes_entre_componentes.WebApp.Data;
using _04_06_Interacoes_entre_componentes.WebApp.Models;
using _04_06_Interacoes_entre_componentes.Domain.Models;
using _04_06_Interacoes_entre_componentes.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace _04_06_Interacoes_entre_componentes.WebApp.Controllers;

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

        var useCase = new RegistrarCliente(context,form.Nome, new Email(form.Email), form.CPF, form.Celular, form.CEP, form.Rua, form.Numero, form.Complemento, form.Bairro, form.Municipio, form.Estado);

        await useCase.ExecutarAsync();

        return RedirectToAction("Sucesso");
    }
}
