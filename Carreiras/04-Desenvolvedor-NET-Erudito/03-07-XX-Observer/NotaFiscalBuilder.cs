using System;
using System.Collections.Generic;

namespace _03_07_XX_Observer
{
    public class NotaFiscalBuilder
    {
        private string RazaoSocial;
        private string Cnpj;
        private double ValorTotal;
        private double Impostos;
        public DateTime Data { get; private set; }
        public string Observacoes { get; private set; }
        private double ValorBruto { get; set; }

        private IList<ItemDaNota> TodosItens = new List<ItemDaNota>();
        private IList<IAcaoAposGerarNota> TodasAcoesASeremExecutadas;

        public NotaFiscalBuilder()
        {
            Data = DateTime.Now;
            TodasAcoesASeremExecutadas = new List<IAcaoAposGerarNota>();
        }

        public NotaFiscalBuilder(IList<IAcaoAposGerarNota> lista)
        {
            Data = DateTime.Now;
            TodasAcoesASeremExecutadas = lista;
        }

        public NotaFiscalBuilder ParaEmpresa(string razaoSocial)
        {
            RazaoSocial = razaoSocial;

            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            Cnpj = cnpj;

            return this;
        }

        public NotaFiscalBuilder Com(ItemDaNota item)
        {
            TodosItens.Add(item);
            ValorBruto += item.Valor;
            Impostos += item.Valor * 0.05;

            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string observacoes)
        {
            Observacoes = observacoes;

            return this;
        }

        public NotaFiscalBuilder NaData(DateTime novaData)
        {
            this.Data = novaData;

            return this;
        }

        public NotaFiscal Constroi()
        {
            NotaFiscal nf = new NotaFiscal(RazaoSocial, Cnpj, Data, ValorBruto, Impostos, TodosItens, Observacoes);

            foreach (var acao in TodasAcoesASeremExecutadas)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        public void AdicionaAcao(IAcaoAposGerarNota novaAcao)
        {
            TodasAcoesASeremExecutadas.Add(novaAcao);
        }
    }
}
