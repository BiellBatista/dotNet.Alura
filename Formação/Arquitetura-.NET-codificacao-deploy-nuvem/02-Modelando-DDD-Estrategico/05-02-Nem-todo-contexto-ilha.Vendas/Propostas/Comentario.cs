namespace _05_02_Nem_todo_contexto_ilha.Vendas.Propostas;

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