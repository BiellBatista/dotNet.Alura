namespace _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Request;

public record OfertaViagemRequest(RotaRequest rota, PeriodoRequest periodo, double preco, double desconto);