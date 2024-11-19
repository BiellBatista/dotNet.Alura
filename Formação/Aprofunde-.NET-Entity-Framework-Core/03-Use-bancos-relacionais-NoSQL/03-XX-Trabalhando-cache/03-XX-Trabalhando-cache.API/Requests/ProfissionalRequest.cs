namespace _03_XX_Trabalhando_cache.API.Requests;

public record ProfissionalRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeRequest> Especialidades);