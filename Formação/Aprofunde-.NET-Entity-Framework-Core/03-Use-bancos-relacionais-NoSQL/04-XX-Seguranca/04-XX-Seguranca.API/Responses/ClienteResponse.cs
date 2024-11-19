namespace _04_XX_Seguranca.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);