namespace _04_XX_Seguranca.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, Guid ProjetoId);