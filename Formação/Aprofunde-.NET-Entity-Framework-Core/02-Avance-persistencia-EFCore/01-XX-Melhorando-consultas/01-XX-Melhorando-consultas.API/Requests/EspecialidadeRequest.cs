namespace _01_XX_Melhorando_consultas.API.Requests;

public record EspecialidadeRequest(Guid Id, string? Descricao, ICollection<ProjetoRequest> Projetos, ICollection<ProfissionalRequest> Profissionais);