namespace _01_02_XX_Acoplamento
{
    public class Frete : IServicoDeEntrega
    {
        public double Para(string cidade)
        {
            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            else
            {
                return 30;
            }
        }
    }
}
