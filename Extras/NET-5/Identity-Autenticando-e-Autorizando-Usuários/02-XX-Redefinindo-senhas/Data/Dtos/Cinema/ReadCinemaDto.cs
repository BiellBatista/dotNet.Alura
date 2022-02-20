using _02_XX_Redefinindo_senhas.Models;
using System.ComponentModel.DataAnnotations;

namespace _02_XX_Redefinindo_senhas.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}