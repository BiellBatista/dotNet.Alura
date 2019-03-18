using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_NET_Identity_Parte_3.ViewModels
{
    public class ContaRegistrarViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nome Completo")] // alterando a visualização na view
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress] // validação de e-mail
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // indicando que o campo é uma senha
        public string Senha { get; set; }
    }
}