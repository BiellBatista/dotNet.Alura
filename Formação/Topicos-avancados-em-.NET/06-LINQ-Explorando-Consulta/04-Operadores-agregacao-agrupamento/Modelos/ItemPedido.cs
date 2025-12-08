namespace _04_Operadores_agregacao_agrupamento.Modelos;

public class ItemPedido
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public Guid ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
}