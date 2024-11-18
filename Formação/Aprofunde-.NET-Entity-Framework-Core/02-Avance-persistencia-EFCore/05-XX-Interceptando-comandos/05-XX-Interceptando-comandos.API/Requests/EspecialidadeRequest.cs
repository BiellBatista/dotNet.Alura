namespace _05_XX_Interceptando_comandos.API.Requests;

public record EspecialidadeRequest(Guid Id, string? Descricao, ICollection<ProjetoRequest> Projetos, ICollection<ProfissionalRequest> Profissionais);