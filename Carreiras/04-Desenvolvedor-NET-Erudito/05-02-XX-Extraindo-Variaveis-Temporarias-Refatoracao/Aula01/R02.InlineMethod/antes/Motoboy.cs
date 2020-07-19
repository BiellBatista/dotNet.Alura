namespace _05_02_XX_Extraindo_Variaveis_Temporarias_Refatoracao.R02.InlineMethod.antes
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
