using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_3.ViewModels
{
    public class ContaConfirmacaoAlteracaoSenhaViewModel
    {
        [HiddenInput(DisplayValue = false)] //ocultando este campo no @Html.EditorForModel()
        public string UsuarioId { get; set; }
        [HiddenInput(DisplayValue = false)] //ocultando este campo no @Html.EditorForModel()
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }
    }
}