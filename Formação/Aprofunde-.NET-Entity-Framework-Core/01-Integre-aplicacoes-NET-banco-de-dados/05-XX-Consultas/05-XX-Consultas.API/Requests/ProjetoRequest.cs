using _05_XX_Consultas.Modelos;

namespace _05_XX_Consultas.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);