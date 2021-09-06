using System;

namespace _04_06_XX_Excecoes_SQL_Server_Rede.Depois
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