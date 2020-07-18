namespace _04_09_XX_Facades_Singletons.Command
{
    public class FinalizaPedido : IComando
    {
        public Pedido Pedido { get; private set; }

        public FinalizaPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            System.Console.WriteLine("Finalizando o pedido do cliente {0}", Pedido.Cliente);
            Pedido.Finaliza();
        }
    }
}
