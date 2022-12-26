using System.ComponentModel.DataAnnotations;

namespace _01_XX_Testes_Interface_Usando_Selenium.Domain.Entidades
{
    public class UsuarioApp
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}