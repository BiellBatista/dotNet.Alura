using _02_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico;
using _02_XX_CI_CD_Azure_DevOps.Application.DTO;
using _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _02_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;
using _02_XX_CI_CD_Azure_DevOps.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_CI_CD_Azure_DevOps.WebApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IClienteServico _servico;
        private readonly ClienteServicoApp clienteServicoApp;

        public ClientesController(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        // GET: Clientes
        [Authorize]
        public IActionResult Index()
        {
            return View(clienteServicoApp.ObterTodos());
        }

        // GET: Clientes/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                clienteServicoApp.Adicionar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clienteServicoApp.Atualizar(id, cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id.Value);

            if (cliente == null)
            {
                return NotFound();
            }

            clienteServicoApp.Excluir(id.Value);
            return RedirectToAction(nameof(Index));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = clienteServicoApp.ObterPorId(id);
            clienteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            var cliente = clienteServicoApp.ObterPorId(id);
            return cliente == null ? true : false;
        }
    }
}