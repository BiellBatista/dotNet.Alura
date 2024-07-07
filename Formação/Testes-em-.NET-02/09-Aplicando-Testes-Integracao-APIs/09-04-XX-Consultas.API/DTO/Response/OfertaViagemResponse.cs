namespace _09_04_XX_Consultas.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco, double desconto);