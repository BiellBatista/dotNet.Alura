using _04_06_XX_Bridges.Bridges;
using System;

namespace _04_06_XX_Bridges
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMensagem mensagem = new MensagemAdministrativa("victor");
            IEnviador enviador = new EnviaPorEmail();
            mensagem.Enviador = enviador;

            mensagem.Envia();

            Console.ReadLine();
        }
    }
}

/**
 * Você consegue ver alguma relação entre o Bridge e o Strategy? Qual?
 * 
 * Na implementação do bridge que fizemos nesse capítulo, podemos ver que o bridge pode utilizar o strategy em sua implementação: a mensagem em seu método Envia utiliza o strategy para decidir qual é a estratégia de envio que será utilizada pela aplicação.
 */
