namespace _04_Operadores_agregacao_agrupamento.Modelos;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public List<Pedido> Pedidos { get; set; }
}