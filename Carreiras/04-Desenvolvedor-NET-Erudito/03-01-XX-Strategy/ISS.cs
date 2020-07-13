namespace _03_01_XX_Strategy
{
    public class ISS : ICMS
    {
        public double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
}
