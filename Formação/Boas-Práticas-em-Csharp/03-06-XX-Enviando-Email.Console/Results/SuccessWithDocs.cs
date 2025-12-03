using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentacao { get; }

    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}