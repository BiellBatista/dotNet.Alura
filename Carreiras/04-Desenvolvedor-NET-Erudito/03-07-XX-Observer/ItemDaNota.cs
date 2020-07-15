namespace _03_07_XX_Observer
{
    public class ItemDaNota
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public ItemDaNota(string descricao, double valor)
        {
            Descricao = descricao;
            Valor = valor;
        }
    }
}
