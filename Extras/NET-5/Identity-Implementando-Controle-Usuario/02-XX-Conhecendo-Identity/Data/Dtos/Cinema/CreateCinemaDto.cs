using System.ComponentModel.DataAnnotations;

namespace _02_XX_Conhecendo_Identity.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
    }
}