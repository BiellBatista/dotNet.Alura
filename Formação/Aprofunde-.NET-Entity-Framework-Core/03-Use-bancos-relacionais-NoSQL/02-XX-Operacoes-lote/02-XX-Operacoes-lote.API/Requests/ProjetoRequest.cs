using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);