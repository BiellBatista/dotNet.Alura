namespace _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco, double desconto);