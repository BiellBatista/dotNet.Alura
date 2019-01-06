using _05_XX_XX_BibliotecasDLLs.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_XX_XX_ListTLambdaLinq.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            // Retornar negativo quando a instância prece o obj
            // Retornar zero quando a instância e o obj são equivalentes
            // Retornar positivo diferente de zero quando a precedencia for de obj

            if (x == y)
                return 0;
            else if (x == null)
                return 1;
            else if (y == null)
                return -1;
            return x.Agencia.CompareTo(y.Agencia);

            //else if (x.Agencia < y.Agencia)
            //    return -1; //x fica na frente de y
            //else if (x.Agencia == y.Agencia)
            //    return 0; //são equivalentes
            //else
            //    return 1; //y fica na frente de y
        }
    }
}
