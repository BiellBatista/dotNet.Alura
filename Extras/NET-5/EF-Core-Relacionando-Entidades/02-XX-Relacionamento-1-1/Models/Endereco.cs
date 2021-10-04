using System.ComponentModel.DataAnnotations;

namespace _02_XX_Relacionamento_1_1.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

        public Cinema Cinema { get; set; }
    }
}