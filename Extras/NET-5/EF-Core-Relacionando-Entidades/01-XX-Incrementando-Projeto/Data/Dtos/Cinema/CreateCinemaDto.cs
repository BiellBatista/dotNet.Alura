using System.ComponentModel.DataAnnotations;

namespace _01_XX_Incrementando_Projeto.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}