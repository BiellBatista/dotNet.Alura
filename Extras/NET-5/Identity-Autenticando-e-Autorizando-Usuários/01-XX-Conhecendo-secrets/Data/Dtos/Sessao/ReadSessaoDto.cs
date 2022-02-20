using _01_XX_Conhecendo_secrets.Models;
using System;

namespace _01_XX_Conhecendo_secrets.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}