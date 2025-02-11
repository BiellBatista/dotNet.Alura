﻿using _03_XX_Usuario.API.Data.Dtos;
using _03_XX_Usuario.API.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Usuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);

            if (resultado.IsFailed) return StatusCode(500);

            return Ok();
        }
    }
}