﻿using _03_XX_Filmes.API.Data;
using _03_XX_Filmes.API.Data.Dtos;
using _03_XX_Filmes.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Filmes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSessao(CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);

        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> RecuperaSessoes()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaSessoesPorId(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

        if (sessao is not null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }

        return NotFound();
    }
}