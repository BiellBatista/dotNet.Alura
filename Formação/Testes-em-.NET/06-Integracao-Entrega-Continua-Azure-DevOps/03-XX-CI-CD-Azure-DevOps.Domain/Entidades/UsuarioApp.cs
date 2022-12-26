using System.ComponentModel.DataAnnotations;

namespace _03_XX_CI_CD_Azure_DevOps.Domain.Entidades
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