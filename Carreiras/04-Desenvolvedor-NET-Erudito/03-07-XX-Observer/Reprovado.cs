using System;

namespace _03_07_XX_Observer
{
    public class Reprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orcamentos reprovados nao recebem desconto extra.");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja esta em estado de reprovado");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento ja esta em estado de reprovado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}
