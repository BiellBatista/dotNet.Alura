using System.ComponentModel.DataAnnotations;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
    }
}