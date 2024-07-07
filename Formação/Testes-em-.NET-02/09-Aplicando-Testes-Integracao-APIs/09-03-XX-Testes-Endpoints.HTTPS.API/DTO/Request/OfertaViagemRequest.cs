namespace _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Request;

public record OfertaViagemRequest(RotaRequest rota, PeriodoRequest periodo, double preco, double desconto);