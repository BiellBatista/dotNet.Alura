namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco);