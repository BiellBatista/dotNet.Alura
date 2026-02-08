namespace _02_03_Identificando_areas_funcionais.API.Domain;

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