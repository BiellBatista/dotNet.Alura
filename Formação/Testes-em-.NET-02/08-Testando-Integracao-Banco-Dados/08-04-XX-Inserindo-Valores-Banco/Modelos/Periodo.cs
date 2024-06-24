using _08_04_XX_Inserindo_Valores_Banco.Validador;

namespace _08_04_XX_Inserindo_Valores_Banco.Modelos;

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