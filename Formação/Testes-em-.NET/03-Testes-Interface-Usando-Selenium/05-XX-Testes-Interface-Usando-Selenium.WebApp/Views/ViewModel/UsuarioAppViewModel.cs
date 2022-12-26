using System.ComponentModel.DataAnnotations;

namespace _05_XX_Testes_Interface_Usando_Selenium.WebApp.Views.ViewModel
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