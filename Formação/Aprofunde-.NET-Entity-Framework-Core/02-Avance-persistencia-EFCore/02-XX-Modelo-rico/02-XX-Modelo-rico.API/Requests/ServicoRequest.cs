using _02_XX_Modelo_rico.Modelos;

namespace _02_XX_Modelo_rico.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);