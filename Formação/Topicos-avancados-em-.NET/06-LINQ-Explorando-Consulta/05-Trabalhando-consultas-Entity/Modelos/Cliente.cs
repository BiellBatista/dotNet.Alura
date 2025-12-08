namespace _05_Trabalhando_consultas_Entity.Modelos;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public List<Pedido> Pedidos { get; set; }
}