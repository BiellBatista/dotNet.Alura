using System;

namespace _04_01_XX_Fluxo_Programa_If_Else_Switch.Depois
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {
        }

        public OperacaoFinanceiraException(string mensagem)
            : base(mensagem)
        {
        }

        public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {
        }
    }
}