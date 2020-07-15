using System;
using System.Collections.Generic;

namespace _03_07_XX_Observer
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataDeEmissao { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public IList<ItemDaNota> Itens { get; private set; }
        public string Observacoes { get; private set; }

        public NotaFiscal(string razaoSocial, string cnpj, DateTime dataDeEmissao,
                      double valorBruto, double impostos, IList<ItemDaNota> itens,
                      string observacoes)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            DataDeEmissao = dataDeEmissao;
            ValorBruto = valorBruto;
            Impostos = impostos;
            Itens = itens;
            Observacoes = observacoes;
        }
    }
}
