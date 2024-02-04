﻿using FluentResults;

namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentacao { get; }

    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}