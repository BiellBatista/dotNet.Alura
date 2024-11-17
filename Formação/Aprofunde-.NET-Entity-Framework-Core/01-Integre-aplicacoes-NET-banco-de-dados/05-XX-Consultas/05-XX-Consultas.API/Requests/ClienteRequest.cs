namespace _05_XX_Consultas.API.Requests;

public record ClienteRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<ProjetoRequest> Projetos);