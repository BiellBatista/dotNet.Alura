using _05_02_XX_Extraindo_Variaveis_Temporarias.Vault;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Inwords
{
    public class MoedaBRL : Moeda
    {
        protected override string MoedaSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaBRLSingular"); }
        protected override string MoedaPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaBRLPlural"); }

        public MoedaBRL(double numero) : base(numero)
        {
        }
    }
}
