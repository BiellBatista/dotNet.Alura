namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Aplicacao.DTO
{
    public class AgenciaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }
        public Guid Identificador { get; set; }

        public AgenciaDTO()
        {
            Identificador = Guid.NewGuid();
        }
    }
}