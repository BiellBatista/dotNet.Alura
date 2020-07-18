namespace _05_01_XX_Extraindo_Metodos_Refatoracao.R02.InlineMethod.depois
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
