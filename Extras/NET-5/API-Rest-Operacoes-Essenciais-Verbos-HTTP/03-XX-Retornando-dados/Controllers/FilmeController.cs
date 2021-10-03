using _03_XX_Retornando_dados.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _03_XX_Retornando_dados.Controllers
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