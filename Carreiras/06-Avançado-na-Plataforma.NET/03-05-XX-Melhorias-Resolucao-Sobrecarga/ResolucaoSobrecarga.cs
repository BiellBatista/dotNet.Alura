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

    class MelhoriaDeSobrecarga
    {
        void TestaMelhoria()
        {
            EscreveMensagem("mensagem", 2);
        }

        public void EscreveMensagem<T>(T objeto, int numero) where T : IDisposable
        {
            Console.WriteLine(objeto);
        }

        public void EscreveMensagem<T>(T objeto, short numero)
        {
            Console.WriteLine(objeto);
        }
    }

    class TesteDeSobrecarga
    {
        void Teste()
        {
            TesteDelegate(int.Parse);
            TesteDelegate(EscreveMensagem);
        }

        public void TesteDelegate(Func<string, int> func) => Console.WriteLine("Func<string, int>");

        public void TesteDelegate(Action<string> action) => Console.WriteLine("Action<string>");

        public void EscreveMensagem(string a) => Console.WriteLine(a);
    }
}
