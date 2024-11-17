namespace _05_XX_Consultas.API.Responses;

public record ProfissionalResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeResponse> Especialidades);