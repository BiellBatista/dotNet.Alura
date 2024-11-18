namespace _03_XX_Topicos_Transacoes.API.Responses;

public record ClienteResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone);