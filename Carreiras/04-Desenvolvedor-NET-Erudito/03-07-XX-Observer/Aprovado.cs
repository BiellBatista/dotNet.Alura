using System;

namespace _03_07_XX_Observer
{
    public class Aprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            orcamento.Valor = orcamento.Valor - (orcamento.Valor * 0.02);
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja esta em estado de aprovacao");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja esta em estado de aprovacao, nao pode ser reprovado agora");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}
