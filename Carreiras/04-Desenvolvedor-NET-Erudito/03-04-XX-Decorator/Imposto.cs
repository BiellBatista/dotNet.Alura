﻿namespace _03_04_XX_Decorator
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; set; }

        public Imposto(Imposto outroImposto)
        {
            OutroImposto = outroImposto;
        }

        public Imposto()
        {
            OutroImposto = null;
        }

        public abstract double Calcula(Orcamento orcamento);

        protected double CalculoDoOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto is null)
                return 0;

            return OutroImposto.Calcula(orcamento);
        }
    }
}
