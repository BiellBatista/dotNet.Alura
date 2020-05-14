namespace _01_01_XX_Coesao_S
{
    public class Funcionario
    {
        public Cargo Cargo { get; private set; }
        public double SalarioBase { get; private set; }

        public Funcionario(Cargo cargo, double salarioBase)
        {
            Cargo = cargo;
            SalarioBase = salarioBase;
        }

        public double CalcularSalario()
        {
            return this.Cargo.Regra.Calcular(this);
        }
    }
}
