namespace _04_09_XX_Facades_Singletons.Memento
{
    public class Estado
    {
        public Contrato Contrato { get; private set; }

        public Estado(Contrato contrato)
        {
            Contrato = contrato;
        }
    }
}
