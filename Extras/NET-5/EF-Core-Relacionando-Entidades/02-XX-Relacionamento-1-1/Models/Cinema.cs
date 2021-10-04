using System.ComponentModel.DataAnnotations;

namespace _02_XX_Relacionamento_1_1.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        //referência do endereço. Neste caso, o cinema é a entidade "fraca"
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }
    }
}