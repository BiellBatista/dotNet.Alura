using System;
using System.Collections.Generic;

namespace _03_03_XX_Template_Method
{
    public class IHIT : TemplateDeImpostoCondicional
    {
        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            IList<String> noOrcamento = new List<String>();

            foreach (Item item in orcamento.Itens)
            {
                if (noOrcamento.Contains(item.Nome))
                    return true;
                else
                    noOrcamento.Add(item.Nome);
            }

            return false;
        }

        public override double MaximaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.13 + 100;
        public override double MinimaTaxacao(Orcamento orcamento) => orcamento.Valor * (0.01 * orcamento.Itens.Count);
    }
}
