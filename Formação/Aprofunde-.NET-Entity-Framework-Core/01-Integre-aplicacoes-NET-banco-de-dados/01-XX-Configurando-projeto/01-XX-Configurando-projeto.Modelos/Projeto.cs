namespace _01_XX_Configurando_projeto.Modelos;

public class Projeto
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public StatusProjeto Status { get; set; }
}