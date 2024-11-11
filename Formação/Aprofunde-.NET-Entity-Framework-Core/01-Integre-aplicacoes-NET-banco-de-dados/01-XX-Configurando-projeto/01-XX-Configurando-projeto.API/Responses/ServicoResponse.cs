namespace _01_XX_Configurando_projeto.API.Responses;

public record ServicoResponse(Guid Id, string? Titulo, string? Descricao, StatusServico? Status);