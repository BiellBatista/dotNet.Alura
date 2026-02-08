namespace _03_02_Refletindo_linguagem_negocio.API.Domain;

public class Comentario
{
    public Comentario()
    { }

    public Guid Id { get; set; }
    public string Texto { get; set; }
    public string Usuario { get; set; }
    public DateTime Data { get; set; }
    public Guid PropostaId { get; set; }
    public Proposta Proposta { get; set; }
}