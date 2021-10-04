using System.ComponentModel.DataAnnotations;

namespace _01_XX_Incrementando_Projeto.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}