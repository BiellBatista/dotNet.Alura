using _03_XX_Relacionamentos.Modelos;

namespace _03_XX_Relacionamentos.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);