﻿namespace _03_XX_Topicos_Transacoes.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, Guid ProjetoId);