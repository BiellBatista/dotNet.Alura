using _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Vault;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Inwords
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
