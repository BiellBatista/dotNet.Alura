namespace _10_05_XX_Fluxo_Completo.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco);