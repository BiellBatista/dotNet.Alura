namespace _09_02_XX_Compartilhando_Contexto.API.DTO.Request;

public record OfertaViagemRequest(RotaRequest rota, PeriodoRequest periodo, double preco, double desconto);