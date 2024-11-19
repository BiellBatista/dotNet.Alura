using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);