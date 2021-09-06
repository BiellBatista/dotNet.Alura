using System;

namespace _04_06_XX_Excecoes_SQL_Server_Rede.Antes
{
    public class OperacaoFinanceiraException6 : Exception
    {
        public OperacaoFinanceiraException6()
        {
        }

        public OperacaoFinanceiraException6(string mensagem)
            : base(mensagem)
        {
        }

        public OperacaoFinanceiraException6(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {
        }
    }
}