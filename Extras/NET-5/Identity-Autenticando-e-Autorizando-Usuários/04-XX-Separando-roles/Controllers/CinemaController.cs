﻿using _04_XX_Separando_roles.Data.Dtos.Cinema;
using _04_XX_Separando_roles.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _04_XX_Separando_roles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}