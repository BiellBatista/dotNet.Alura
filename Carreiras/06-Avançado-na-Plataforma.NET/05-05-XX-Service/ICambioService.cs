namespace _05_05_XX_Service
{
    public interface ICambioService
    {
        decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor);
    }
}
