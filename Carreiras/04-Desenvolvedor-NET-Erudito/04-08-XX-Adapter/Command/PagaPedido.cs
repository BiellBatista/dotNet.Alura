namespace _04_08_XX_Adapter.Command
{
    public class PagaPedido : IComando
    {
        public Pedido Pedido { get; private set; }

        public PagaPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            System.Console.WriteLine("Pagando o pedido do cliente {0}", Pedido.Cliente);
            Pedido.Paga();
        }
    }
}
