namespace _04_XX_Seguranca.API.Requests;

public record ClienteRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<ProjetoRequest> Projetos);