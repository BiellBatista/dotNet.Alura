using System.ComponentModel.DataAnnotations;

namespace _01_XX_Incrementando_Projeto.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public object Endereco { get; set; }
    }
}