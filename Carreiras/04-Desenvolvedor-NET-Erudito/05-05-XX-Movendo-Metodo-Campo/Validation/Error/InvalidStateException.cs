using System;
using System.Collections.Generic;
using System.Text;

namespace _05_05_XX_Movendo_Metodo_Campo.Validation.Error
{
    public class InvalidStateException : Exception
    {
        private readonly List<string> _errors;
        public InvalidStateException(List<string> errors)
        {
            _errors = errors;
        }

        public List<string> GetErrors()
        {
            return _errors;
        }

        public override string Message => string.Join("\n -", _errors);
    }
}
