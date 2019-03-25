using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity_Parte_4.ViewModels
{
    public class ContaVerificacaoDoisFatoresViewModel
    {
        [Required]
        [Display(Name = "Token de SMS")]
        public string Token { get; set; }

        [Display(Name = "Continuar Logado")]
        public bool ContinuarLogado { get; set; }

        [Display(Name = "Lembrar este Computador")]
        public bool LembrarNavegador { get; set; }
    }
}