namespace _01_01_XX_Coesao_S
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
