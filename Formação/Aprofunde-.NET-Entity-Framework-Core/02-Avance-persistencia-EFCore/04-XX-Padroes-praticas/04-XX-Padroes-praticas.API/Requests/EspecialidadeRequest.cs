namespace _04_XX_Padroes_praticas.API.Requests;

public record EspecialidadeRequest(Guid Id, string? Descricao, ICollection<ProjetoRequest> Projetos, ICollection<ProfissionalRequest> Profissionais);