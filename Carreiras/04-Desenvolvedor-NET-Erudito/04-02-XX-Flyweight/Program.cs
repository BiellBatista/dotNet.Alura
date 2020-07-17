using _04_02_XX_Flyweight.Flyweight;
using System.Collections.Generic;

namespace _04_02_XX_Flyweight
{
    public class Program
    {
        static void Main(string[] args)
        {
            NotasMusicais notas = new NotasMusicais();
            IList<INota> musica = new List<INota>()
            {
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("fa"),
                notas.Pega("fa"),
            };
            Piano piano = new Piano();

            piano.Toca(musica);
        }
    }
}

/**
 * Qual a diferença entre Factory e Flyweight?
 * 
 * 
 * Uma Factory instancia uma classe que é importante/complexa, e seu processo de criação deve ser isolado.
 * 
 * Um Flyweight serve para quando temos muitas instâncias do mesmo objeto andando pelo sistema, e precisamos economizar. Para tal, o Flyweight faz uso de uma fábrica modificada, que guarda essas instâncias.
 * 
 * O padrão Singleton. O que você acha dele? Ele se parece com um FlyWeight?
 * 
 * A ideia de ambos é garantir que existam apenas uma única referência para o objeto ao longo do programa.
 * 
 * A diferença é que o Flyweight garante que existam apenas uma única instância de vários elementos. É um "singleton maior".
 */
