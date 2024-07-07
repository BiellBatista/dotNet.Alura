namespace _09_04_XX_Consultas.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, double desconto, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco, desconto);