namespace _01_01_XX_Coesao_S
{
    public class QuinzeOuVinteCincoPorcento : IRegraDeCalculo
    {
        public double Calcular(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 2000.0)
            {
                return funcionario.SalarioBase * 0.75;
            }
            else
            {
                return funcionario.SalarioBase * 0.85;
            }
        }
    }
}
