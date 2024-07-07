namespace _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, double desconto, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco, desconto);