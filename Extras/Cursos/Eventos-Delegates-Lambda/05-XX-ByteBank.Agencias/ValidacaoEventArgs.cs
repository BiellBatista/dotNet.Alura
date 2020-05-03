using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_XX_ByteBank.Agencias
{
    class ValidacaoEventArgs : EventArgs
    {
        public string Texto { get; private set; }
        public bool EhValido { get; set; }

        public ValidacaoEventArgs(string texto)
        {
            Texto = texto;
            EhValido = true;
        }
    }
}
