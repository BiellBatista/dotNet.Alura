using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);