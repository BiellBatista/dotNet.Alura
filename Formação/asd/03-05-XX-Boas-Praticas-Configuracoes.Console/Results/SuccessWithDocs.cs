using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentacao { get; }

    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}