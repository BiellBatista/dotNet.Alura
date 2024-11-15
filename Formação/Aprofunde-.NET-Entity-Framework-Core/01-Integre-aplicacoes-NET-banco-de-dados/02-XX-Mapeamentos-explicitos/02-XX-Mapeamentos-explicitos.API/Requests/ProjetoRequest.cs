namespace _02_XX_Mapeamentos_explicitos.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status);