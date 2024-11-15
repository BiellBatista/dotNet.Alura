﻿using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentacao { get; }

    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}