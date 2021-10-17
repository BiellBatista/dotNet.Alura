using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _05_XX_Executando_Consultas.Models
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

        public int GerenteId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public virtual List<Sessao> Sessoes { get; set; }
    }
}