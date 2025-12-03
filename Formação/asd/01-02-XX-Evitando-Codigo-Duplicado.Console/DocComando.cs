namespace _01_02_XX_Evitando_Codigo_Duplicado.Console;

[AttributeUsage(AttributeTargets.Class)]
internal class DocComando : Attribute
{
    public DocComando(string instrucao, string documentacao)
    {
        Instrucao = instrucao;
        Documentacao = documentacao;
    }

    public string Instrucao { get; }

    public string Documentacao { get; }
}