﻿using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity_Parte_3.ViewModels
{
    public class ContaEsqueciSenhaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}