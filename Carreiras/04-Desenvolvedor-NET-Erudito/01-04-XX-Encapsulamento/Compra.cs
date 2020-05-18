namespace _01_04_XX_Encapsulamento
{
    public class Compra
    {
        public double Valor { get; internal set; }
        public string Cidade { get; internal set; }

        public Compra(double valor, string cidade)
        {
            this.Valor = valor;
            this.Cidade = cidade;
        }
    }
}
