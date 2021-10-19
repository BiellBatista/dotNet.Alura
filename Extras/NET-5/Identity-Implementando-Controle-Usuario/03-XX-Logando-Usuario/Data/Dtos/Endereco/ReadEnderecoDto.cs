using System.ComponentModel.DataAnnotations;

namespace _03_XX_Logando_Usuario.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}