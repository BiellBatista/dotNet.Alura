using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity_Parte_4.ViewModels
{
    public class ContaLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Continuar Logado")]
        public bool ContinuarLogado { get; set; }
    }
}