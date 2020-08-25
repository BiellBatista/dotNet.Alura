using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace _04_05_XX_Invocando_Metodos_Assinaturas_Complexas_Dinamicamente.Intraestrutura.Binding
{
    public class ActionBindInfo
    {
        public MethodInfo MethodInfo { get; private set; }
        public IReadOnlyCollection<ArgumentoNomeValor> TuplasArgumentoNomeValor { get; private set; }

        public ActionBindInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> argumentoNomeValores)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(methodInfo));

            if (argumentoNomeValores is null)
            {
                throw new ArgumentNullException(nameof(argumentoNomeValores));
            }

            TuplasArgumentoNomeValor = new ReadOnlyCollection<ArgumentoNomeValor>(argumentoNomeValores.ToList());
        }

        public object Invoke(object controller)
        {
            MethodInfo.Invoke(controller, );
        }
    }
}
