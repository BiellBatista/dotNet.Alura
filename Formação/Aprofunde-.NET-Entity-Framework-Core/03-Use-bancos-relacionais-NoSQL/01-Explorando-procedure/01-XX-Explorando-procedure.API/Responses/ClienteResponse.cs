﻿namespace _01_XX_Explorando_procedure.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);