using _03_XX_Trabalhando_cache.Modelos;

namespace _03_XX_Trabalhando_cache.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);