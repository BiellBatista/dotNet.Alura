namespace _03_03_XX_Importacao_Clientes.Console.Atributos;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocComandoAttribute : Attribute
{
    public DocComandoAttribute(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

    public string Instrucao { get; }
    public string Documentacao { get; }
}