using System;

namespace _01_01_XX_Coesao_S
{
    public class CalculadoraDeSalario
    {
        public double Calcular(Funcionario funcionario)
        {
            return funcionario.Cargo.Regra.Calcular(funcionario);
        }
    }
}
