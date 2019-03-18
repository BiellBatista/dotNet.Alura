using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity_Parte_3.ViewModels
{
    public class ContaRegistrarViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}