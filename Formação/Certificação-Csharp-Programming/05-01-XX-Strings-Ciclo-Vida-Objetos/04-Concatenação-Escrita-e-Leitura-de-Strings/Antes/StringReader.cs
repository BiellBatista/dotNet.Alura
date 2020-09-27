using System;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Antes
{
    class StringReader1 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA:
            //======
            //1) Ler sequencialmente a lista de ingredientes
            //linha a linha.
            //2) Cada Linha deve começar com um caracter "•" e um espaço

            string ingredientes = GetIngredientes();

            Console.WriteLine(ingredientes);

            Console.ReadKey();
        }

        private static string GetIngredientes()
        {
            return @"3 cenouras médias raspadas e picadas
                    3 ovos
                    1 xícara de óleo
                    2 xícaras de açúcar
                    2 xícaras de farinha de trigo
                    1 colher(sopa) de fermento em pó
                    1 pitada de sal";
        }
    }
}
