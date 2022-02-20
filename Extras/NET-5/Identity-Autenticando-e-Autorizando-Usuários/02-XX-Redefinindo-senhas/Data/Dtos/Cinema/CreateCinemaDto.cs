using System.ComponentModel.DataAnnotations;

namespace _02_XX_Redefinindo_senhas.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}