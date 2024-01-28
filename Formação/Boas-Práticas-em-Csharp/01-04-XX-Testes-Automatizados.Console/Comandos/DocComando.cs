namespace _01_04_XX_Testes_Automatizados.Console.Comandos;

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