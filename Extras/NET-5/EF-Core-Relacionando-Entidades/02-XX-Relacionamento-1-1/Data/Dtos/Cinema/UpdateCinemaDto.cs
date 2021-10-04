using System.ComponentModel.DataAnnotations;

namespace _02_XX_Relacionamento_1_1.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}