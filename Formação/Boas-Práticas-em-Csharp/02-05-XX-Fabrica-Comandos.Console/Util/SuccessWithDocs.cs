using FluentResults;

namespace _05_XX_Fabrica_Comandos.Console.Util
{
    internal class SuccessWithDocs : Success
    {
        public IEnumerable<string> Documentacao { get; }

        public SuccessWithDocs(IEnumerable<string> documentacao)
        {
            Documentacao = documentacao;
        }
    }
}