namespace _01_XX_Melhorando_consultas.API.Responses;

public record ProfissionalResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeResponse> Especialidades);