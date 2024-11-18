using _03_XX_Topicos_Transacoes.Modelos;

namespace _03_XX_Topicos_Transacoes.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);