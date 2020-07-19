using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Inwords
{
    public class MoedaEUR : Moeda
    {
        protected override string MoedaSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaEURSingular"); }
        protected override string MoedaPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaEURPlural"); }

        public MoedaEUR(double numeroOrigem) : base(numeroOrigem)
        {
        }
    }
}
