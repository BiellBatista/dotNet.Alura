using System;

namespace _05_06_XX_Formatacao_Strings.Antes
{
    public class Enumerar : IAulaItem
    {
        public void Executar()
        {
            string documento = GetDocumento();

            Console.WriteLine(documento);
            Console.WriteLine();

            //TAREFA:
            //======
            //Imprimir o documento no console, destacando
            //as letras maiúsculas no texto

            Console.ReadKey();
        }

        private static string GetDocumento()
        {
            return "Uma cadeia de caracteres é uma coleção sequencial de caracteres que é usada para representar texto. Um objeto String é uma coleção sequencial de objetos System.Char que representam uma cadeia de caracteres; um System.Char objeto corresponde a uma unidade de código UTF-16. O valor de objeto String é o conteúdo da coleção sequencial de objetos System.Char cujo valor é imutável. Ou seja, ele é somente leitura.";
        }
    }
}
