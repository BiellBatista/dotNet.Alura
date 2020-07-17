using System;

namespace _04_07_XX_Command.Command
{
    public class Pedido
    {
        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public DateTime DataFinalizacao { get; private set; }
        public Status Status { get; private set; }

        public Pedido(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            Status = Status.Novo;
        }

        public void Paga()
        {
            Status = Status.Pago;
        }

        public void Finaliza()
        {
            Status = Status.Entregue;

            DataFinalizacao = DateTime.Now;
        }
    }
}
