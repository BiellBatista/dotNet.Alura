namespace _01_XX_Configurando_projeto.Modelos;

public class Contrato
{
    public Guid Id { get; set; }
    public double Valor { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataEncerramento { get; set; }
}