using _03_XX_Implementando_roles.Models;
using System.ComponentModel.DataAnnotations;

namespace _03_XX_Implementando_roles.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}