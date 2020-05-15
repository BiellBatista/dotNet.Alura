using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_XX_Acoplamento
{
    class GeradorDeNotaFiscal
    {
        private IList<IAcaoAposGerarNota> acoes;

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes)
        {
            this.acoes = acoes;
        }

        public NotaFiscal Gerar(Fatura fatura)
        {
            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobre0(valor));

            foreach(var acao in acoes)
            {
                acao.Executar(nf);
            }

            return nf;
        }

        private double ImpostoSimplesSobre0(double valor)
        {
            return valor * 0.06;
        }
    }
}
