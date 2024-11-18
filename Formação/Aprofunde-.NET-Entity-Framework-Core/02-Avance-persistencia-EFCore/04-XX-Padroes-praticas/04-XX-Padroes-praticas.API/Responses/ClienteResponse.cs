namespace _04_XX_Padroes_praticas.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);