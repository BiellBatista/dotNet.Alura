﻿using System.ComponentModel.DataAnnotations;

namespace _02_XX_MongoDB.Models.Account
{
    public class RegistrarModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}