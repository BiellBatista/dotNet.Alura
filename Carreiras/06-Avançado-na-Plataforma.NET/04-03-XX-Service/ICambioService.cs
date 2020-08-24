namespace _04_03_XX_Service
{
    public interface ICambioService
    {
        decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor);
    }
}
