﻿using System.ComponentModel.DataAnnotations;

namespace _01_XX_Selenium_WebDriver.WebApp.Models
{
    public class RegistroViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Endereço de Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmação de Senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
