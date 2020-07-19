namespace _05_05_XX_Movendo_Metodo_Campo_Refatoracao.R02.InlineMethod.depois
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
