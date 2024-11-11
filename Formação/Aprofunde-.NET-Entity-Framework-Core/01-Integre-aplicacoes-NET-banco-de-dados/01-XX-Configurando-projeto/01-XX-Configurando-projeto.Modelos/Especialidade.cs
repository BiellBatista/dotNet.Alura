namespace _01_XX_Configurando_projeto.Modelos;

[Table("TB_Especialidades")]
public class Especialidade
{
    [Column("ID_Especialidade")]
    public Guid Id { get; set; }

    [Column("DS_Especialidade")]
    public string? Descricao { get; set; }
}