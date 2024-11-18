using _05_XX_Interceptando_comandos.Modelos;

namespace _05_XX_Interceptando_comandos.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);