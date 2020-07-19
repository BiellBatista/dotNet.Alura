namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Refatoracao.R02.InlineMethod.antes
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
