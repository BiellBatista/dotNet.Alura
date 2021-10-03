using _02_XX_Construindo_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _02_XX_Construindo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);

            Console.WriteLine(filme.Titulo);
        }
    }
}