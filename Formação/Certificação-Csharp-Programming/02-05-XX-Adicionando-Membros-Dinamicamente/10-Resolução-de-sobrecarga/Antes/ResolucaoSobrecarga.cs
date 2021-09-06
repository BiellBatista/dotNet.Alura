namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Antes
{
    internal class ResolucaoSobrecarga : IAulaItem
    {
        public void Executar()
        {
            int int1 = 123;
            int int2 = 456;

            short short1 = 123;
            short short2 = 456;

            double double1 = 123.45;
            double double2 = 456.78;
        }

        private int Somar(int parcela1, int parcela2)
        {
            return parcela1 + parcela2;
        }

        private short Somar(short parcela1, short parcela2)
        {
            return (short)(parcela1 + parcela2);
        }

        private object Somar(object parcela1, object parcela2)
        {
            return (double)parcela1 + (double)parcela2;
        }
    }
}