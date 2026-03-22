namespace _03_04_Ultrapassa_agregados.Vendas.Propostas;

public class AprovarProposta
{
    public AprovarProposta(Guid idPedido, Guid idProposta)
    {
        IdPedido = idPedido;
        IdProposta = idProposta;
    }

    public Guid IdPedido { get; }
    public Guid IdProposta { get; }
}