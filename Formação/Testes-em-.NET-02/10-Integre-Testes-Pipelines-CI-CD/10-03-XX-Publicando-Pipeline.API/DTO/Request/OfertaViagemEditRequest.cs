namespace _10_03_XX_Publicando_Pipeline.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco);