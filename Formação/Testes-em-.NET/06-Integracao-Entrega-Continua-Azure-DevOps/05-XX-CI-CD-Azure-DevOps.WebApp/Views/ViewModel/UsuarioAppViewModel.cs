using System.ComponentModel.DataAnnotations;

namespace _05_XX_CI_CD_Azure_DevOps.WebApp.Views.ViewModel
{
    public class UsuarioAppViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}