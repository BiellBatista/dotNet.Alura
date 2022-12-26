﻿using System;
using Microsoft.AspNetCore.Http;
using _05_XX_Selenium_WebDriver.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _05_XX_Selenium_WebDriver.WebApp.Models
{
    public class LeilaoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public string Categoria { get; set; }

        public string Imagem { get; set; }
        public IFormFile ArquivoImagem { get; set; }

        [Required]
        [Display(Name = "Valor Inicial")]
        public double ValorInicial { get; set; }

        [Required]
        [Display(Name = "Início Pregão")]
        public DateTime InicioPregao { get; set; }

        [Required]
        [Display(Name = "Término Pregão")]
        public DateTime TerminoPregao { get; set; }

        public bool SendoSeguido { get; set; }

        public EstadoLeilao Estado { get; set; }

        public IEnumerable<Lance> Lances { get; set; }
    }
}
