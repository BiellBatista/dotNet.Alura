using _10_01_XX_Pipeline_Testes_GitHub_Actions.Dominio.Validacao;
using Microsoft.EntityFrameworkCore;

namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.Dominio.ValueObjects;

[Owned]
public class Periodo : Valida
{
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }

    public Periodo(DateTime dataInicial, DateTime dataFinal)
    {
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        Validar();
    }

    protected override void Validar()
    {
        if (DataInicial > DataFinal)
        {
            Erros.RegistrarErro("Erro: Data de ida não pode ser maior que a data de volta.");
        }
    }
}