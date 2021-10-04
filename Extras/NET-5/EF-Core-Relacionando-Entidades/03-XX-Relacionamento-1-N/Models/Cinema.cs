using System.ComponentModel.DataAnnotations;

namespace _03_XX_Relacionamento_1_N.Models
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

        public virtual Endereco Endereco { get; set; }
    }
}