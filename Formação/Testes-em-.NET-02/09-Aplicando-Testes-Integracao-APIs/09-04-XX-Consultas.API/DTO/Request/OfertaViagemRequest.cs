namespace _09_04_XX_Consultas.API.DTO.Request;

public record OfertaViagemRequest(RotaRequest rota, PeriodoRequest periodo, double preco, double desconto);