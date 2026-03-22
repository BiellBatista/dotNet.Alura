namespace _01_03_Explicitando_casos_uso.Financeiro.Faturamento;

public class Fatura
{
    public Guid Id { get; set; }

    // Ano da emissão + nº da fatura com 16 dígitos, preenchido com zeros à esquerda
    public string Numero { get; set; }

    public DateTime DataEmissao { get; set; }
    public DateTime DataVencimento { get; set; }
    public Guid LocacaoId { get; set; }
    public decimal Total { get; set; }
}