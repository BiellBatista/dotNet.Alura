﻿using _04_XX_Relacionamento_N_N.Data;
using _04_XX_Relacionamento_N_N.Data.Dtos.Endereco;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _04_XX_Relacionamento_N_N.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IMapper _mapper;

        private AppDbContext _context;

        public EnderecoController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperaEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco is not null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return Ok(enderecoDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco is null) return NotFound();

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null) return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}