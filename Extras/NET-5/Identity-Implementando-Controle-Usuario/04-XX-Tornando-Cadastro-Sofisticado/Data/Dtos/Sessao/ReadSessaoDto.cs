using System;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int SessaoId { get; set; }
        public Models.Cinema Cinema { get; set; }
        public Models.Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}