namespace _04_XX_Padroes_praticas.API.Responses;

public record ProjetoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, ClienteResponse Cliente, ICollection<EspecialidadeResponse> Especialidades);