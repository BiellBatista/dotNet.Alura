using _02_XX_Mapeamentos_explicitos.Modeloss;

namespace _02_XX_Mapeamentos_explicitos.Modelos;

public class Contrato
{
    public Contrato()
    {
    }

    public Contrato(Guid id, double valor, Vigencia vigencia)
    {
        Id = id;
        Valor = valor;
        Vigencia = vigencia;
    }

    public Guid Id { get; set; }
    public double Valor { get; set; }
    public Vigencia? Vigencia { get; set; }
}