using Alura.Financas.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Alura.FinancasWeb.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var cliente = new Cliente("Fulano de Tal");
			var conta = new Conta("12387-12", cliente);

			conta.Deposita(500);
			conta.Saca(200);

			return Ok($"O saldo da conta é {conta.Saldo}");
		}
	}
}