namespace _03_XX_Padroes_Projeto_Command.Console.Comandos;

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