﻿using _02_XX_Excecoes_ADOPET_API.Dtos;
using _02_XX_Excecoes_ADOPET_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Excecoes_ADOPET_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly PetService _petService;

    public PetController(PetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        List<PetDto> pets = _petService.ListarTodos();
        return Ok(pets);
    }

    [HttpPost]
    public IActionResult Cadastrar([FromForm] CadastroPetDto dados)
    {
        _petService.Cadastrar(dados);
        return Ok();
    }
}