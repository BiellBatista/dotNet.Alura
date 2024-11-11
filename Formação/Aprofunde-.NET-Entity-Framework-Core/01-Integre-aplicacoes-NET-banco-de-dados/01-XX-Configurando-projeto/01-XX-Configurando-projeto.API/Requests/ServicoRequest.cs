namespace _01_XX_Configurando_projeto.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico? Status);