﻿using System;
using System.ComponentModel.DataAnnotations;

namespace _05_XX_Usuario.API.Data.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}