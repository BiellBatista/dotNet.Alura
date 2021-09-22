using System;

namespace _12_08_XX_Fazendo_Hash_Dados.Antes
{
    public class Startup0802 : IAulaItem
    {
        public void Executar()
        {
            ExibirHash("olá, mundo!");
            ExibirHash("mundo, olá!");

            ExibirHash("alura cursos online");
            ExibirHash("cursos online alura");

            Console.ReadLine();
        }

        private void ExibirHash(string mensagem)
        {
            //TAREFA: CALCULAR O HASHCODE PARA A MENSAGEM
            //Console.WriteLine("Hash para {0} é: {1:X}", mensagem, ???);
        }
    }
}