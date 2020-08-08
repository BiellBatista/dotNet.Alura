using System;
using System.Text;

namespace _03_05_XX_Melhorias_Resolucao_Sobrecarga
{
    class ResolucaoSobrecarga
    {
        public void TestaSObreCarga()
        {
            this.EscreveMensagem(null); //chamando o método de instancia (1)
            ResolucaoSobrecarga.EscreveMensagem(null); //chamando o método static (2)
        }

        //1 - metodo de instancia
        public void EscreveMensagem(StringBuilder stringBuilder)
        {
            Console.WriteLine(stringBuilder);
        }


        //2 - metodo static
        public static void EscreveMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
