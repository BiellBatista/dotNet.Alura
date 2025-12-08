namespace _05_Trabalhando_consultas_Entity.Modelos;

public class Pagamento
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime Data { get; set; }
}