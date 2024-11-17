namespace _04_XX_Salvando_dados.API.Requests;

public record ClienteRequest(Guid Id, string? Nome, string? Cpf, string? Email, string? Telefone, ICollection<ProjetoRequest> Projetos);