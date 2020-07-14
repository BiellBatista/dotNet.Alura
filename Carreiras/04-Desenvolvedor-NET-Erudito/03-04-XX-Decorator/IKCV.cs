namespace _03_04_XX_Decorator
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        public IKCV() : base() { }

        public IKCV(Imposto outroImposto) : base(outroImposto) { }

        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento) => orcamento.Valor > 500.0 && TemItemMaiorQue100ReaisNo(orcamento);
        public override double MaximaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.10;
        public override double MinimaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.06;

        private bool TemItemMaiorQue100ReaisNo(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Valor > 100)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
