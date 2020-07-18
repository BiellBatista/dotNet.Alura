using System;

namespace _04_09_XX_Facades_Singletons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

/**
 * Quais são os problemas do Singleton?
 * 
 * O Singleton possibilita que o usuário crie uma instância global para determinado objeto. Isso pode ser interessante, mas tem problemas similares ao de variáveis globais no mundo procedural, afinal o objeto é único e disponível para todos. Se não usar com parcimônia, o seu código sofrerá problemas de manutenção.
 * 
 * Você consegue ver alguma semelhança/diferença entre o Façade o Adapter?
 * O Façade cria uma interface amigável para que clientes consigam consumir sub-sistemas (ou serviços).
 * Já o Adapter tem um propósito diferente. Ele visa adaptar um conjunto de classes que já existem, para uma outra interface, que é a requerida pelo outro sistema.
 */
