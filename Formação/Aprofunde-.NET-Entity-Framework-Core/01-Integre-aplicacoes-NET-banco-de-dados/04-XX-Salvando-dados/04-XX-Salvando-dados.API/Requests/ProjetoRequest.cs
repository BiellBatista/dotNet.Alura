using _04_XX_Salvando_dados.Modelos;

namespace _04_XX_Salvando_dados.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);