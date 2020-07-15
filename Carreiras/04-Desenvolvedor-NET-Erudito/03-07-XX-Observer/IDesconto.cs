namespace _03_07_XX_Observer
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        double Desconta(Orcamento orcamento);
    }
}
