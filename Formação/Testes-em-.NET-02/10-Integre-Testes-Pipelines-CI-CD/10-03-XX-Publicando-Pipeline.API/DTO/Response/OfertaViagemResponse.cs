namespace _10_03_XX_Publicando_Pipeline.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco);