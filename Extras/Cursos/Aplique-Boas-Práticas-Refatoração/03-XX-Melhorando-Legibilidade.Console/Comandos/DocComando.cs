namespace _03_XX_Melhorando_Legibilidade.Console.Comandos;

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