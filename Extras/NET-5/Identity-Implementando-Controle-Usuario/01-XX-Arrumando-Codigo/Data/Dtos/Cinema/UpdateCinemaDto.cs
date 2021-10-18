using System.ComponentModel.DataAnnotations;

namespace _01_XX_Arrumando_Codigo.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}