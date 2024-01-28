namespace _02_02_XX_Boas_Praticas_Testes.Console.Comandos
{
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
}