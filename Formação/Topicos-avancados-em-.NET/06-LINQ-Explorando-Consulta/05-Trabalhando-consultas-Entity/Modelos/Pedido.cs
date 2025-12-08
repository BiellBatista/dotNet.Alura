namespace _05_Trabalhando_consultas_Entity.Modelos;

public class Pedido
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public List<ItemPedido> ItensPedido { get; set; }
    public Pagamento Pagamento { get; set; }
}