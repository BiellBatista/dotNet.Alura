using System;
using System.Collections.Generic;
using System.Text;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Inwords
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
