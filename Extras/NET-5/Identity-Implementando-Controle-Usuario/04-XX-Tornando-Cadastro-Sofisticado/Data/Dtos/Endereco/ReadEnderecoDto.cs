using System.ComponentModel.DataAnnotations;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Endereco
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