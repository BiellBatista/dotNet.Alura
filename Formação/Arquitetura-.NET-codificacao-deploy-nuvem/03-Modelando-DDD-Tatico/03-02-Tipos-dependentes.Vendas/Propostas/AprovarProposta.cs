namespace _03_02_Tipos_dependentes.Vendas.Propostas;

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