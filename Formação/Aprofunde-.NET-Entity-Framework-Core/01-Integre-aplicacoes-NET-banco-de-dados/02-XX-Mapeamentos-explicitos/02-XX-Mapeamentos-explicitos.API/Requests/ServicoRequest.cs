namespace _02_XX_Mapeamentos_explicitos.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status);