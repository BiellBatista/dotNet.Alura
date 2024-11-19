namespace _01_XX_Explorando_procedure.API.Responses;

public record ProjetoResponse(Guid Id, string? Titulo, string? Descricao, string? Status, ClienteResponse Cliente, ICollection<EspecialidadeResponse> Especialidades);