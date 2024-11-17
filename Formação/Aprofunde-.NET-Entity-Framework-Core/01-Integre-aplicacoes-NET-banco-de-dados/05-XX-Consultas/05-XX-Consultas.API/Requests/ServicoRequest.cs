using _05_XX_Consultas.Modelos;

namespace _05_XX_Consultas.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);