using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class Dinamicos : IAulaItem
    {
        public void Executar()
        {
            object objeto = 1;
            //objeto = objeto + 3;

            //com o tipo dynamic, o tipo do objeto (variavel) é resolvido em tempo de execução
            dynamic dinamico = 1;
            dinamico = dinamico + 3;

            Console.WriteLine(dinamico);

            //este código dar erro, porque o tipo está definido como int, por causa das linhas de cima
            dinamico.teste();

            /**
             * A existência dos membros de um objeto dynamic são verificados somente em tempo de execução.
             */
        }
    }
}