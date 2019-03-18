using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_NET_Identity_Parte_3.ViewModels
{
    public class ContaEsqueciSenhaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}