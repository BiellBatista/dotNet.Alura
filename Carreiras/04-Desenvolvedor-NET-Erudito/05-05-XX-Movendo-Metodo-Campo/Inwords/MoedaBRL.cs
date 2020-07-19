using _05_05_XX_Movendo_Metodo_Campo.Vault;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_05_XX_Movendo_Metodo_Campo.Inwords
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
