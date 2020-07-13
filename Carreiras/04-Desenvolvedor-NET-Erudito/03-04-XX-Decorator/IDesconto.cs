namespace _03_04_XX_Decorator
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        double Desconta(Orcamento orcamento);
    }
}
