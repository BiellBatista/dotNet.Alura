using System.ComponentModel.DataAnnotations;

namespace _01_XX_Conhecendo_secrets.Data.Dtos
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