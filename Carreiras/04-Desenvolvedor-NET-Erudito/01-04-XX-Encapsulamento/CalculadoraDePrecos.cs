namespace _01_04_XX_Encapsulamento
{
    public class CalculadoraDePrecos
    {
        private ITabelaDePreco tabela { get; set; }
        private IServicoDeEntrega entrega { get; set; }

        public CalculadoraDePrecos(ITabelaDePreco tabela, IServicoDeEntrega entrega)
        {
            this.tabela = tabela;
            this.entrega = entrega;
        }

        public double Calcular(Compra produto)
        {
            double desconto = tabela.DescontoPara(produto.Valor);
            double frete = entrega.Para(produto.Cidade);

            return produto.Valor * (1 - desconto) + frete;
        }
    }
}
