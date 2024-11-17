using _04_XX_Salvando_dados.Modelos;

namespace _04_XX_Salvando_dados.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);