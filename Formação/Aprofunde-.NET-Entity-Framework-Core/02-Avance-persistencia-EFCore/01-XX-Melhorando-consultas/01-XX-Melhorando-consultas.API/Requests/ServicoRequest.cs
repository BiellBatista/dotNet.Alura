using _01_XX_Melhorando_consultas.Modelos;

namespace _01_XX_Melhorando_consultas.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);