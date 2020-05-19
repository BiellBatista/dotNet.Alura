using System.Collections.Generic;

namespace _01_04_XX_Encapsulamento
{
    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        private IList<Pagamento> pagamentos;
        public bool Pago { get; private set; }

        public Fatura(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            pagamentos = new List<Pagamento>();
            Pago = false;
        }

        public void AdicionaPagamento(Pagamento pagamento)
        {
            pagamentos.Add(pagamento);

            if (ValorTotalDosPagamentos() >= Valor)
            {
                Pago = true;
            }
        }

        private double ValorTotalDosPagamentos()
        {
            double total = 0;

            foreach (Pagamento pagamento in pagamentos)
            {
                total += pagamento.Valor;
            }

            return total;
        }
    }
}
