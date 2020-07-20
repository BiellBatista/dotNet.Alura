using _05_08_XX_Introduzir_Metodo_Estrangeiro.Vault;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Inwords
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
