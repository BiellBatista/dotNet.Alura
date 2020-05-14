namespace _01_02_XX_Acoplamento
{
    public abstract class Cargo
    {
        public IRegraDeCalculo Regra { get; private set; }

        protected Cargo(IRegraDeCalculo regra)
        {
            Regra = regra;
        }
    }
}
