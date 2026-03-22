namespace _02_04_Aprovacao_proposta.Vendas.Propostas;

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