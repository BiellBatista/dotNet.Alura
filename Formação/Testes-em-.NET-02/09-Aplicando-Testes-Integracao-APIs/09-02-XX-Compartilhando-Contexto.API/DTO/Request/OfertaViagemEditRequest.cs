namespace _09_02_XX_Compartilhando_Contexto.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, double desconto, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco, desconto);