namespace _05_08_XX_Introduzir_Metodo_Estrangeiro_Refatoracao.R02.InlineMethod.antes
{
    class Motoboy
    {
        private int qtdeEntregasNoturnas;

        int GetAvaliacao()
        {
            return (TemMaisDeCincoEntregasNoturnas()) ? 2 : 1;
        }

        bool TemMaisDeCincoEntregasNoturnas()
        {
            return qtdeEntregasNoturnas > 5;
        }
    }
}
