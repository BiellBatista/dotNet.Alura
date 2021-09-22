using System;

namespace _12_08_XX_Fazendo_Hash_Dados.Depois
{
    public class Startup0801 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA: CALCULAR O "CHECK SUM" PARA AS MENSAGENS

            ExibirChecksum("olá, mundo!");
            ExibirChecksum("mundo, olá!");

            ExibirChecksum("alura cursos online");
            ExibirChecksum("cursos online alura");

            Console.ReadLine();
        }

        private void ExibirChecksum(string origem)
        {
            Console.WriteLine("Checksum para {0} é {1}", origem, CalcularChecksum(origem));
        }

        private int CalcularChecksum(string mensagem)
        {
            //TAREFA: CALCULAR O "CHECK SUM" PARA A MENSAGEM
            int soma = 0;

            foreach (var ch in mensagem)
            {
                soma += ch;
            }

            return soma;
        }
    }
}