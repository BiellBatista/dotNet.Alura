namespace _04_XX_Padroes_praticas.API.Requests;

public record ClienteRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<ProjetoRequest> Projetos);