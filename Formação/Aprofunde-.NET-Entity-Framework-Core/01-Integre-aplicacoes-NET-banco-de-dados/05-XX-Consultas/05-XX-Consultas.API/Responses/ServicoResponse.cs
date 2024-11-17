namespace _05_XX_Consultas.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, Guid ProjetoId);