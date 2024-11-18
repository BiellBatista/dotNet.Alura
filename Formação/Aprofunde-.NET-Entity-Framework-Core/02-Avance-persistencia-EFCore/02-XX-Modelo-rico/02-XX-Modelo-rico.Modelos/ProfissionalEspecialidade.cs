namespace _02_XX_Modelo_rico.Modelos;

public class ProfissionalEspecialidade
{
    public Guid EspecialidadeId { get; set; }
    public Especialidade Especialidade { get; set; }

    public Guid ProfissionalId { get; set; }
    public Profissional Profissional { get; set; }
}