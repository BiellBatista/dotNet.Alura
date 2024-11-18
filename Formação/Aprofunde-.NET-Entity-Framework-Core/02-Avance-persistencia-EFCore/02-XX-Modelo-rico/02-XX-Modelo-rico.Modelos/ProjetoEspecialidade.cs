namespace _02_XX_Modelo_rico.Modelos;

public class ProjetoEspecialidade
{
    public Guid EspecialidadeId { get; set; }
    public Especialidade Especialidade { get; set; }

    public Guid ProjetoId { get; set; }
    public Projeto Projeto { get; set; }
}