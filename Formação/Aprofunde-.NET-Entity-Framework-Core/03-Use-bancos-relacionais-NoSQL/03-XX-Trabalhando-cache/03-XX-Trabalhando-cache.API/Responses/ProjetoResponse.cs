namespace _03_XX_Trabalhando_cache.API.Responses;

public record ProjetoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, ClienteResponse Cliente, ICollection<EspecialidadeResponse> Especialidades);