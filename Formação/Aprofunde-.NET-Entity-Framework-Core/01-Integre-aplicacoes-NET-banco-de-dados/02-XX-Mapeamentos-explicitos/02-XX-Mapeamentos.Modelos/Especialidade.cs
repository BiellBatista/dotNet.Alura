namespace _02_XX_Mapeamentos_explicitos.Modelos;

public class Especialidade
{
    public Especialidade()
    {
    }

    public Especialidade(Guid id, string? descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public Guid Id { get; set; }
    public string? Descricao { get; set; }
}