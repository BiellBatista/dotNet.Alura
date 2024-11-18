using _02_XX_Modelo_rico.Modelos;

namespace _02_XX_Modelo_rico.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);