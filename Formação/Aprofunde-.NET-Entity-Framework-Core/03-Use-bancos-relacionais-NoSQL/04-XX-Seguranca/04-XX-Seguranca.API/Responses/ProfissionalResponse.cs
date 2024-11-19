namespace _04_XX_Seguranca.API.Responses;

public record ProfissionalResponse(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeResponse> Especialidades);