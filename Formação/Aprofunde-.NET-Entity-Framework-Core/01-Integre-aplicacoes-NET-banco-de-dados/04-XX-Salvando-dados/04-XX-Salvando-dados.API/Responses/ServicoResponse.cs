namespace _04_XX_Salvando_dados.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, Guid ProjetoId);