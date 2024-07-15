namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Request;

public record OfertaViagemRequest(RotaRequest rota, PeriodoRequest periodo, double preco);