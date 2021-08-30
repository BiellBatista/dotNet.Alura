using System;
using System.IO;

namespace _08_04_XX_Gerenciando_Diretorios.Depois
{
    public class LerGravarStringsFluxosArquivos02 : IAulaItem
    {
        public void Executar()
        {
            //TAREFA: Usar FileStream dá muito trabalho...
            //        Não podemos usar algo mais simples??

            using (StreamWriter gravadorFluxo = new StreamWriter("ArquivoSaida.txt"))
            {
                gravadorFluxo.Write("Olá, Alura! (gravado com StreamWriter)");
            }

            using (StreamReader leitorFluxo = new StreamReader("ArquivoSaida.txt"))
            {
                string textoLido = leitorFluxo.ReadToEnd();
                Console.WriteLine("Texto lido: {0}", textoLido);
                Console.ReadKey();
            }
        }
    }
}