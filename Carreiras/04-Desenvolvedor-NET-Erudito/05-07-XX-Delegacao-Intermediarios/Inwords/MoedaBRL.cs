using _05_07_XX_Delegacao_Intermediarios.Vault;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_07_XX_Delegacao_Intermediarios.Inwords
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
