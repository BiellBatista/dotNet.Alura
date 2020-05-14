namespace _01_02_XX_Acoplamento
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
