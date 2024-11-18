using _01_XX_Melhorando_consultas.Modelos;

namespace _01_XX_Melhorando_consultas.API.Requests;

public record ProjetoRequest(Guid Id, string? Titulo, string? Descricao, StatusProjeto Status, ClienteRequest
    Cliente, ICollection<EspecialidadeRequest> Especialidades);