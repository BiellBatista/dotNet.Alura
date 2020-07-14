namespace _03_05_XX_State
{
    public class ICPP : TemplateDeImpostoCondicional
    {
        public ICPP() : base() { }

        public ICPP(Imposto outroImposto) : base(outroImposto) { }
        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento) => orcamento.Valor >= 500.0;
        public override double MaximaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.07;
        public override double MinimaTaxacao(Orcamento orcamento) => orcamento.Valor * 0.05;
    }
}
