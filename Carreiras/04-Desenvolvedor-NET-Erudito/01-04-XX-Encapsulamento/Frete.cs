namespace _01_04_XX_Encapsulamento
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
