namespace _02_XX_Mapeamentos_explicitos.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);