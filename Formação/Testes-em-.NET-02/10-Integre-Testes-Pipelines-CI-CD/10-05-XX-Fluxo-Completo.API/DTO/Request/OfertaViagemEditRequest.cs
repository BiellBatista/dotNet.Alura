namespace _10_05_XX_Fluxo_Completo.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco);