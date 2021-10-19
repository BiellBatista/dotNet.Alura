using System;

namespace _03_XX_Logando_Usuario.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}