﻿using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Gerente;
using _04_XX_Tornando_Cadastro_Sofisticado.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);

            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentesPorId(id);

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeleteGerente(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }
    }
}