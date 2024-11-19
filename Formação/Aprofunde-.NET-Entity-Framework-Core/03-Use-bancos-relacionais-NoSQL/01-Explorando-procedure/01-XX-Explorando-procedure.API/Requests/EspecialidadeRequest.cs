namespace _01_XX_Explorando_procedure.API.Requests;

public record EspecialidadeRequest(Guid Id, string? Descricao, ICollection<ProjetoRequest> Projetos, ICollection<ProfissionalRequest> Profissionais);