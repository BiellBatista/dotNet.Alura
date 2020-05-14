namespace _01_02_XX_Acoplamento
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
