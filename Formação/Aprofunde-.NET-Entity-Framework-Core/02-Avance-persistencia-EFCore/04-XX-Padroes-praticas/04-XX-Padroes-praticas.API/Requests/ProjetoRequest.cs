using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);