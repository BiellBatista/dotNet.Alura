using System;

namespace _12_04_XX_Funcoes_Internas_Validar_Tipos_Conteudos.Antes
{
    public class Startup0402 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA: EXIBIR O DOBRO DE UM NÚMERO DIGITADO,
            //VALIDANDO CONTRA STRING VAZIA, ESPAÇOS EM BRANCO E NÚMERO INVÁLIDO

            bool valido = true;
            int numero = 0;
            string entrada;

            do
            {
                Console.WriteLine("Digite um número:");

                entrada = Console.ReadLine();

                //valido = ???

                if (!valido)
                {
                    Console.WriteLine("Entrada inválida!");
                }
            } while (!valido);

            Console.WriteLine("O dobro de {0} é {1}", numero, numero * 2);
            Console.ReadLine();
        }
    }
}