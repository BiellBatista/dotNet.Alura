namespace _02_XX_Mapeamentos_explicitos.API.Requests;

public record ClienteRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);