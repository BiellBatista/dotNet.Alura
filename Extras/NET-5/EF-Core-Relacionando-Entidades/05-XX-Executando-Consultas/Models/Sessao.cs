using System;
using System.ComponentModel.DataAnnotations;

namespace _05_XX_Executando_Consultas.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
    }
}