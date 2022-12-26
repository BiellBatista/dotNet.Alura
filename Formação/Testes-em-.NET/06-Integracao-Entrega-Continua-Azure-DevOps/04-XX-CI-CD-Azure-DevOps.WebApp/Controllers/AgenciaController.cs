using _04_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico;
using _04_XX_CI_CD_Azure_DevOps.Domain.Services;
using _04_XX_CI_CD_Azure_DevOps.Application.DTO;
using _04_XX_CI_CD_Azure_DevOps.Application.Interfaces;
using _04_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _04_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _04_XX_CI_CD_Azure_DevOps.WebApp.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: AgenciaController
        private readonly IAgenciaRepositorio _repositorio;

        private readonly IAgenciaServico _servico;
        private readonly IAgenciaServicoApp agenciaServicoApp;

        public AgenciaController(IAgenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new AgenciaServico(_repositorio);
            agenciaServicoApp = new AgenciaServicoApp(_servico);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(agenciaServicoApp.ObterTodos());
        }

        // GET: AgenciaController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            return View(agencia);
        }

        // GET: AgenciaController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind("Id,Identificador,Numero,Nome,Endereco")] AgenciaDTO agencia)
        {
            try
            {
                agenciaServicoApp.Adicionar(agencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(agencia);
            }
        }

        // GET: AgenciaController/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var agencia = agenciaServicoApp.ObterPorId(id.Value);
            if (agencia == null)
            {
                return NotFound();
            }
            return View(agencia);
        }

        // POST: AgenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,Numero,Nome,Endereco")] AgenciaDTO agencia)
        {
            if (id != agencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    agenciaServicoApp.Atualizar(id, agencia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaExists(agencia.Id))
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
            return View(agencia);
        }

        // GET: AgenciaController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);

            if (agencia == null)
            {
                return NotFound();
            }

            agenciaServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: AgenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            agenciaServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaExists(int id)
        {
            var agencia = agenciaServicoApp.ObterPorId(id);
            return agencia == null ? true : false;
        }
    }
}