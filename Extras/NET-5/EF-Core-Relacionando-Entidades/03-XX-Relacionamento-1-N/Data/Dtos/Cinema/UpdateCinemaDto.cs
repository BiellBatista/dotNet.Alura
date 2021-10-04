using System.ComponentModel.DataAnnotations;

namespace _03_XX_Relacionamento_1_N.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}