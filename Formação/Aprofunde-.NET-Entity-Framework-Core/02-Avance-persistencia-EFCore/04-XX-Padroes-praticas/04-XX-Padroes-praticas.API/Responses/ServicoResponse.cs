namespace _04_XX_Padroes_praticas.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, Guid ProjetoId);