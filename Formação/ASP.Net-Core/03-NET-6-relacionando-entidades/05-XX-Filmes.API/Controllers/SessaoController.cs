﻿using _05_XX_Filmes.API.Data;
using _05_XX_Filmes.API.Data.Dtos;
using _05_XX_Filmes.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Filmes.API.Controllers;

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

        return CreatedAtAction(nameof(RecuperaSessoesPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> RecuperaSessoes()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{filmeId}/{cinemaId}")]
    public IActionResult RecuperaSessoesPorId(int filmeId, int cinemaId)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);

        if (sessao is not null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }

        return NotFound();
    }
}