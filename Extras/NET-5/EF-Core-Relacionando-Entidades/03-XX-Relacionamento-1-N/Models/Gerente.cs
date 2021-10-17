using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_XX_Relacionamento_1_N.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }
    }
}