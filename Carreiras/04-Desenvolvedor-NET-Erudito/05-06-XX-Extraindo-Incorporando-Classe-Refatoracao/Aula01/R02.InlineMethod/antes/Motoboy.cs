namespace _05_06_XX_Extraindo_Incorporando_Classe_Refatoracao.R02.InlineMethod.antes
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
