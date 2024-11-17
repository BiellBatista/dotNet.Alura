namespace _05_XX_Consultas.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);