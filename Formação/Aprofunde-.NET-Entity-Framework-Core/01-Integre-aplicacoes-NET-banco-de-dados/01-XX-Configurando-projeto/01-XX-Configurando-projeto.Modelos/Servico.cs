namespace _01_XX_Configurando_projeto.Modelos;

public class Servico
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public StatusServico Status { get; set; }
}