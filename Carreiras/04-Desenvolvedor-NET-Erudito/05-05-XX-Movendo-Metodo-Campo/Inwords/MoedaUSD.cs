using System;
using System.Collections.Generic;
using System.Text;

namespace _05_05_XX_Movendo_Metodo_Campo.Inwords
{
    public class MoedaUSD : Moeda
    {
        protected override string MoedaSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaUSDSingular"); }
        protected override string MoedaPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaUSDPlural"); }

        public MoedaUSD(double numeroOrigem) : base(numeroOrigem)
        {
        }
    }
}
