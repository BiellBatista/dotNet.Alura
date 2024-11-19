namespace _01_XX_Configurando_projeto.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto? Status);