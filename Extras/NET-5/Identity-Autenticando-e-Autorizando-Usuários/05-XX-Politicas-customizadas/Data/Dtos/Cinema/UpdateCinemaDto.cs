﻿using System.ComponentModel.DataAnnotations;

namespace _05_XX_Politicas_customizadas.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}