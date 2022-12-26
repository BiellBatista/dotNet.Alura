namespace _03_XX_CI_CD_Azure_DevOps.Application.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public Guid Identificador { get; set; }

        public ClienteDTO()
        {
            Identificador = Guid.NewGuid();
        }
    }
}