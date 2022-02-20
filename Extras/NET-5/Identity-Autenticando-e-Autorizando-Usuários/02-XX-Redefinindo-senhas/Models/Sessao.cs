using System;
using System.ComponentModel.DataAnnotations;

namespace _02_XX_Redefinindo_senhas.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}