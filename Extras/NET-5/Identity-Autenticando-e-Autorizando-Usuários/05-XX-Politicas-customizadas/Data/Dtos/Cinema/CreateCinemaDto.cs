using System.ComponentModel.DataAnnotations;

namespace _05_XX_Politicas_customizadas.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}