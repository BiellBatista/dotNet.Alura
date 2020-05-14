namespace _01_02_XX_Acoplamento
{
    public class DezOuVintePorcento : IRegraDeCalculo
    {
        public double Calcular(Funcionario funcionario)
        {
            if (funcionario.SalarioBase > 3000.0)
            {
                return funcionario.SalarioBase * 0.8;
            }
            else
            {
                return funcionario.SalarioBase * 0.9;
            }
        }
    }
}
