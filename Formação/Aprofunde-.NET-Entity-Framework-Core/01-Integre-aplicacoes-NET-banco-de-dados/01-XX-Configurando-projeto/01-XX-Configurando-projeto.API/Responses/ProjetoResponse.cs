namespace _01_XX_Configurando_projeto.API.Responses;

public record ProjetoResponse(Guid Id, string? Titulo, string? Descricao, StatusProjeto? Status);