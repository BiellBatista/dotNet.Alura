using System;

namespace _12_08_XX_Fazendo_Hash_Dados.Antes
{
    public class Startup0803 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA: CRIAR UM HASH COM 32 BYTES PARA CADA MENSAGEM

            ExibirHash("olá, mundo!");
            ExibirHash("mundo, olá!");

            ExibirHash("alura cursos online");
            ExibirHash("cursos online alura");

            Console.ReadLine();
        }

        private static void ExibirHash(string origem)
        {
            Console.Write("Hash para {0} é: ", origem);

            byte[] hash = CalcularHash(origem);

            foreach (byte b in hash)
            {
                Console.Write("{0:X} ", b);
            }

            Console.WriteLine();
        }

        private static byte[] CalcularHash(string mensagem)
        {
            byte[] hash = null;

            //TAREFA: CRIAR UM HASH COM 32 BYTES PARA CADA MENSAGEM

            return hash;
        }
    }
}