namespace _04_04_XX_Interpreter.Memento
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
