namespace _03_06_XX_Enviando_Email.Console.Atributos;

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