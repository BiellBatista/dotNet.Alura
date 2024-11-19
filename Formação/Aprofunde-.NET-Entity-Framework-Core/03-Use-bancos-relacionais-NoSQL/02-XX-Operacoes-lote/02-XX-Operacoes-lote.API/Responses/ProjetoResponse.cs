namespace _02_XX_Operacoes_lote.API.Responses;

public record ProjetoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, ClienteResponse Cliente, ICollection<EspecialidadeResponse> Especialidades);