namespace _02_Projecoes_transformacoes.Modelos;

public class Pagamento
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime Data { get; set; }
}