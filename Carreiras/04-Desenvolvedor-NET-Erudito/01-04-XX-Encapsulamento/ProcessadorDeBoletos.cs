using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_04_XX_Encapsulamento
{
    public class ProcessadorDeBoletos
    {
        public void Processar(IList<Boleto> boletos, Fatura fatura)
        {

            foreach (Boleto boleto in boletos)
            {
                Pagamento pagamento = new Pagamento(boleto.Valor);
                fatura.AdicionaPagamento(pagamento);
            }
        }
    }
}
