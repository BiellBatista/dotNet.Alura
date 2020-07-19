namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros_Refatoracao.R02.InlineMethod.depois
{
    class Motoboy
    {
        private int qtdeEntregasNoturnas;

        int GetAvaliacao()
        {
            return (qtdeEntregasNoturnas > 5) ? 2 : 1;
        }
    }
}
