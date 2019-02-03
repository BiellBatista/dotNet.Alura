using System;
using System.Collections.Generic;

namespace _11_01_XX_ColecoesOrdenadas
{
    internal class ComparadorMinusculo : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}