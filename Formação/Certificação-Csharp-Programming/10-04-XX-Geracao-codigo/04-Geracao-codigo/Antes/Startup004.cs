using System;

namespace _10_04_XX_Geracao_codigo.Antes
{
    //Gerar código em tempo de execução usando expressões CodeDom e lambda
    public class Startup004 : IAulaItem
    {
        public void Executar()
        {
            Func<float, float> metade = quo => quo / 2;
            Console.WriteLine("Metade de 9 é {0}", metade(9));

            //TAREFA: Recriar a Função acima,
            //porém usando árvore de expressões LINQ

            Console.ReadLine();
        }
    }
}