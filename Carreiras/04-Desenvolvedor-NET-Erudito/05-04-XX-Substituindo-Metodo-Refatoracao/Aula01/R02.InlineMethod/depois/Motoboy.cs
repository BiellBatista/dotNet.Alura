namespace _05_04_XX_Substituindo_Metodo_Refatoracao.R02.InlineMethod.depois
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
