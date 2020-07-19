using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Inwords
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
