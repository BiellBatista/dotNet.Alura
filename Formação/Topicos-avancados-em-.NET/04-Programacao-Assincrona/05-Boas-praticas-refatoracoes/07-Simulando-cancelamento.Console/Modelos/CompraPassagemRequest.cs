namespace _07_Simulando_cancelamento.Console.Modelos;

public record CompraPassagemRequest
{
    public string? Origem { get; set; }
    public string? Destino { get; set; }
    public int Milhas { get; set; }
}