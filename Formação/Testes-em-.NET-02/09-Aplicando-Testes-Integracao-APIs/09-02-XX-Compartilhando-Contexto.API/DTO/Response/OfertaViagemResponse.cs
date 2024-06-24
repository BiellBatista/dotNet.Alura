namespace _09_02_XX_Compartilhando_Contexto.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco, double desconto);