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

        public NotaFiscalBuilder()
        {
            Data = DateTime.Now;
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
            return new NotaFiscal(RazaoSocial, Cnpj, Data, ValorBruto, Impostos, TodosItens, Observacoes);
        }
    }
}
