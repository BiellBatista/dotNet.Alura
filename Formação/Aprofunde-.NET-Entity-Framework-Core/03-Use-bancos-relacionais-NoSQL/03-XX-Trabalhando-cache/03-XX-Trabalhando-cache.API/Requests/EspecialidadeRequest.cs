namespace _03_XX_Trabalhando_cache.API.Requests;

public record EspecialidadeRequest(Guid Id, string? Descricao, ICollection<ProjetoRequest> Projetos, ICollection<ProfissionalRequest> Profissionais);