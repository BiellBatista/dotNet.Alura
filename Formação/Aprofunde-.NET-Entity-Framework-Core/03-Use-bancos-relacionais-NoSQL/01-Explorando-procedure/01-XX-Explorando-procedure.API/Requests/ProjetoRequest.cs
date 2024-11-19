using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);