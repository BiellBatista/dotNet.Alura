namespace _01_XX_Configurando_projeto.Modelos;

public class Candidatura
{
    public Guid Id { get; set; }
    public double ValorProposto { get; set; }
    public string? DescricaoProposta { get; set; }
    public DuracaoEmDias DuracaoProposta { get; set; }
    public StatusCandidatura Status { get; set; }
}