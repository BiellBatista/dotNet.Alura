﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05_04_XX_Substituindo_Metodo.Inwords
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
