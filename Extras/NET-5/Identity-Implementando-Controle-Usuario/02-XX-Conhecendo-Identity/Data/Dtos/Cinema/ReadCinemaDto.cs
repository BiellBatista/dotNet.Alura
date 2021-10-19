﻿using System.ComponentModel.DataAnnotations;

namespace _02_XX_Conhecendo_Identity.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}