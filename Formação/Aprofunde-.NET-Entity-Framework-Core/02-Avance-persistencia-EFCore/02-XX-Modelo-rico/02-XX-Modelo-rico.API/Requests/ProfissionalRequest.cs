namespace _02_XX_Modelo_rico.API.Requests;

public record ProfissionalRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeRequest> Especialidades);