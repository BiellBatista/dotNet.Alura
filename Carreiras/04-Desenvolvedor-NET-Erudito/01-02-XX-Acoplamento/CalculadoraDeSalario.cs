using System;

namespace _01_02_XX_Acoplamento
{
    public class CalculadoraDeSalario
    {
        public double Calcular(Funcionario funcionario)
        {
            return funcionario.CalcularSalario();
        }
    }
}
