namespace _04_XX_Salvando_dados.API.Requests;

public record ProfissionalRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<EspecialidadeRequest> Especialidades);